using ShoppingStripe.Infrastructure;
using ShoppingStripe.Models;

namespace ShoppingStripe.Services;

public class CartService : ICartService
{
    private readonly List<CartItem> _cartItems;

    public CartService()
    {
        _cartItems = new List<CartItem>();
    }

    public void AddToCart(ProductResponse product, int qty)
    {
        var existingItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);

        if (existingItem != null)
        {
            existingItem.Qty += qty;
        }
        else
        {
            var newItem = new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Qty = qty,
                Price = product.Price
            };

            _cartItems.Add(newItem);
        }
    }
    
    public List<CartItem> GetCartItems()
    {
        return _cartItems;
    }
}