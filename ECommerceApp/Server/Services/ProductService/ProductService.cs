namespace ECommerceApp.Server.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }


    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var response = new ServiceResponse<Product>();
        var product = await _context.Products.FindAsync(productId);
        if (product == null)
        {
            response.Success = false;
            response.Message = "Verkar som att produkten inte är tillgänglig för tillfället!";
        }
        else
        {
            response.Data = product;
        }
        return response;

    }

    public async Task<ServiceResponse<List<Product>>> GetProductAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _context.Products.ToListAsync()
        };
        return response;
    }

   
}
