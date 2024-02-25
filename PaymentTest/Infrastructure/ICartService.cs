using PaymentTest.Data.Entities;

namespace PaymentTest.Infrastructure;

public interface ICartService
{
    Task AddToCartAsync(ProductEntity product, int qty, CancellationToken cancellationToken);
}