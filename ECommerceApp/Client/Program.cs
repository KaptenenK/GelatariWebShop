global using ECommerceApp.Shared;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Components;
global using ECommerceApp.Client.Services.ProductService;
global using ECommerceApp.Client.Services.CategoryService;
using ECommerceApp.Client;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ECommerceApp.Client.Services.CategoryService;
using Blazored.LocalStorage;
using ECommerceApp.Client.Services.CartService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
await builder.Build().RunAsync();
