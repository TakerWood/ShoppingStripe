using ShoppingStripe.Models;

namespace ShoppingStripe.Infrastructure;

public interface ICartService
{
    void AddToCart(ProductResponse product, int qty);
    List<CartItem> GetCartItems();
}