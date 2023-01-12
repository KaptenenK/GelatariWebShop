using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text.Json;

namespace ECommerceApp.Client;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;
    private readonly HttpClient _http;

    public CustomAuthStateProvider(ILocalStorageService localStorageService, HttpClient http)
    {
        _localStorageService = localStorageService;
        _http = http;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {

        //Auth token får vi från localstorage
        string authToken = await _localStorageService.GetItemAsStringAsync("authToken");


        //om det inte finns authtokens då skapar vi en tom claimsidentity default null och då vet vi att user är unauthorized
        var identity = new ClaimsIdentity();

        _http.DefaultRequestHeaders.Authorization = null;


        //den koden ska inte bli excutad om det finns en authtoken i localstorage
        //om vi får en authtoken, parsar vi den och får claims

        if(!string.IsNullOrEmpty(authToken) )
        {
            try
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authToken.Replace("\"",""));
            }
            catch 
            {
                await _localStorageService.RemoveItemAsync(authToken);
                identity = new ClaimsIdentity();
            }

        }
        //här skapar vi en ny tom user identity
        var user = new ClaimsPrincipal(identity);


        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }

    private byte[] ParseBase64WithoutPadding (string base64)
    {
        switch(base64.Length % 4)
        {
            case 2: base64 += "==";
                break;
            case 3: base64 += "=";
                break;
        }
        return Convert.FromBase64String(base64);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer
            .Deserialize<Dictionary<string, object>>(jsonBytes);

        var claims = keyValuePairs.Select(KeyValuePair => new Claim(KeyValuePair.Key, KeyValuePair.Value.ToString()));
        return claims;
    }
}
