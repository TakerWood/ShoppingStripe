using PaymentTest.Data.Entities;
using PaymentTest.Infrastructure;
using PaymentTest.Models;

namespace PaymentTest.Services;

public class CartService : ICartService
{
    private List<CartItem> cartItems = new List<CartItem>();

    public IReadOnlyList<CartItem> CartItems => cartItems.AsReadOnly();

    public CartService()
    {
        
    }

    public async Task AddToCartAsync(ProductEntity product, int qty, CancellationToken cancellationToken)
    {
        var existingItem = cartItems.FirstOrDefault(item => item.ProductId == product.Id);

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

            cartItems.Add(newItem);
        }
    }
}