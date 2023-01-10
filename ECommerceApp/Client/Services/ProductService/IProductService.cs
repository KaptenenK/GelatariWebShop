﻿using ECommerceApp.Shared;

namespace ECommerceApp.Client.Services.ProductService;

public interface IProductService
{
    //för att säga till komponenten att något har ändrats lägger vi till event

    event Action ProductsChanged;

    List<Product> Products { get; set; }
    string Message { get; set; }
    int CurrentPage { get; set; }
    int PageCount { get; set; }
    
    string LastSearchText { get; set; }
    Task GetProducts(string? categoryUrl = null);

    Task<ServiceResponse<Product>> GetProduct (int productId);
    Task SearchProducts(string searchText, int page);
    Task<List<string>> GetProductSearchSuggestions(string searchText);
}
