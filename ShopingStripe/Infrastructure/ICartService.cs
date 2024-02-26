using ShoppingStripe.Data.Entities;
using ShoppingStripe.Models;

namespace ShoppingStripe.Infrastructure;

public interface ICartService
{
    void AddToCart(ProductEntity product, int qty);
    IReadOnlyList<CartItem> CartItems { get; }
}