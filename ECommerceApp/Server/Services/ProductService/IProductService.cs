namespace ECommerceApp.Server.Services.ProductService;

public interface IProductService
{

    //Här lägger vi till services
    Task<ServiceResponse<List<Product>>> GetProductAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int productId);
    Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
    Task<ServiceResponse<ProductSearchResultDTO>> SearchProducts(string searchText, int page);
    Task<ServiceResponse<List<string>>> GetProductSearchSuggestions (string searchText);
    Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
}
