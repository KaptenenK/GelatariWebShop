namespace ECommerceApp.Server.Services.CartService;

public interface ICartService
{
    Task<ServiceResponse<List<CartProductDTO>>> GetCartProducts(List<CartItem> cartItems);
    Task<ServiceResponse<List<CartProductDTO>>> StoreCartItems(List<CartItem> cartItems);

    //för att få antal items från servern

    Task<ServiceResponse<int>> GetCartItemsCount();


    //hämta cart items från server eller databasen
    Task<ServiceResponse<List<CartProductDTO>>> GetDbCartProducts();
    Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);

    Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);


    Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId);
}
