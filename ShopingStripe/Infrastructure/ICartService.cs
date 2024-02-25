using ShoppingStripe.Data.Entities;

namespace ShoppingStripe.Infrastructure;

public interface ICartService
{
    Task AddToCartAsync(ProductEntity product, int qty, CancellationToken cancellationToken);
}