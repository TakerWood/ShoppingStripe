using ShoppingStripe.Data.Entities;

namespace ShoppingStripe.Infrastructure;

public interface IProductsService
{
    Task<List<ProductEntity>> GetProductsAsync(int page, int pageSize,
        CancellationToken cancellationToken);

    Task SetProductAsync(ProductEntity product, CancellationToken cancellationToken);
}