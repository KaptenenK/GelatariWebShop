global using ECommerceApp.Shared;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Components;
global using ECommerceApp.Client.Services.ProductService;
global using ECommerceApp.Client.Services.CategoryService;
global using ECommerceApp.Client.Services.CartService;
global using ECommerceApp.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
global using ECommerceApp.Client.Services.OrderService;
global using ECommerceApp.Client.Services.AddressService;


using ECommerceApp.Client;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();


builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
