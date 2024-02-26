using ShoppingStripe.Data.Entities;
using ShoppingStripe.Infrastructure;
using ShoppingStripe.Models;

namespace ShoppingStripe.Services;

public class CartService : ICartService
{
    private readonly List<CartItem> _cartItems = new();

    public IReadOnlyList<CartItem> CartItems => _cartItems.AsReadOnly();

    public void AddToCart(ProductEntity product, int qty)
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
                TotalAmount = product.Price * qty
            };

            _cartItems.Add(newItem);
        }
    }
}