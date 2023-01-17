namespace ECommerceApp.Client.Services.CartService;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(CartItem cartItem);
    
    Task<List<CartProductDTO>> GetCartProducts();
    Task RemoveProductFromCart(int productId, int productTypeId);

    Task UpdateQuantity(CartProductDTO product);

    //boolean flag för att tömma local cart
    Task StoreCartItems(bool emptyLocalCart);

    Task GetCartItemsCount();
}
