﻿using ECommerceApp.Shared;

namespace ECommerceApp.Client.Services.ProductService;

public interface IProductService
{
    List<Product> Products { get; set; }
    Task GetProducts();
}