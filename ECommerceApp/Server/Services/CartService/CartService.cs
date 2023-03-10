using ECommerceApp.Shared;
using System.Security.Claims;

namespace ECommerceApp.Server.Services.CartService;

public class CartService : ICartService
{
    private readonly DataContext _context;
    private readonly IAuthservice _authService;

    public CartService(DataContext context, IAuthservice authService)
    {
        _context = context;
        _authService = authService;
    }

    public async Task<ServiceResponse<List<CartProductDTO>>> GetCartProducts(List<CartItem> cartItems)
    {
        var result = new ServiceResponse<List<CartProductDTO>>
        {
            Data = new List<CartProductDTO>()
        };

        foreach (var item in cartItems)
        {
            var product = await _context.Products
                .Where(p => p.Id == item.ProductId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                continue;
            }

            var productVariant = await _context.ProductVariants
                .Where(v => v.ProductId == item.ProductId
                    && v.ProductTypeId == item.ProductTypeId)
                .Include(v => v.ProductType)
                .FirstOrDefaultAsync();

            if (productVariant == null)
            {
                continue;
            }

            var cartProduct = new CartProductDTO
            {
                ProductId = product.Id,
                Title = product.Title,
                ImageUrl = product.ImageUrl,
                Price = productVariant.Price,
                ProductType = productVariant.ProductType.Name,
                ProductTypeId = productVariant.ProductTypeId,
                Quantity = item.Quantity
                
            };

            result.Data.Add(cartProduct);
        }

        return result;
    }

    public async Task<ServiceResponse<List<CartProductDTO>>> StoreCartItems(List<CartItem> cartItems)
    {
        cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
        _context.CartItems.AddRange(cartItems);
        await _context.SaveChangesAsync();

        return await GetDbCartProducts();
    }

    public async Task<ServiceResponse<int>> GetCartItemsCount()
    {
        var count = (await _context.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count();
        return new ServiceResponse<int> { Data = count };
    }

    public async Task<ServiceResponse<List<CartProductDTO>>> GetDbCartProducts(int? userId = null)
    {
        if(userId == null)
        {
            userId = _authService.GetUserId();
        }

        return await GetCartProducts(await _context.CartItems
            .Where(ci => ci.UserId == userId).ToListAsync());
    }

    public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
    {
        cartItem.UserId = _authService.GetUserId();
        //kollar om vi har samma item först
        var sameTime = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
           ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == cartItem.UserId);
        if(sameTime == null)
        {
            _context.CartItems.Add(cartItem);
        }

        else
        {
            sameTime.Quantity += cartItem.Quantity;
        }

        await _context.SaveChangesAsync();
        return new ServiceResponse<bool> { Data = true }; 
    }

    public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
    {
        var dbCartItem = await _context.CartItems
            .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
           ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == _authService.GetUserId());
        if (dbCartItem == null)
        {
            return new ServiceResponse<bool>
            {
                Data = false,
                Success = false,
                Message = "Varan du söker är inte tillgänglig, vänligt kontakta support!"
            };
        }

        dbCartItem.Quantity = cartItem.Quantity;
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> { Data= true };
    }

    public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
    {
        var dbCartItem = await _context.CartItems
           .FirstOrDefaultAsync(ci => ci.ProductId == productId &&
          ci.ProductTypeId == productTypeId && ci.UserId == _authService.GetUserId());
        if (dbCartItem == null)
        {
            return new ServiceResponse<bool>
            {
                Data = false,
                Success = false,
                Message = "Varan du söker är inte tillgänglig, vänligt kontakta support!"
            };
        }

        _context.CartItems.Remove(dbCartItem);
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> { Data= true };
    }
}
