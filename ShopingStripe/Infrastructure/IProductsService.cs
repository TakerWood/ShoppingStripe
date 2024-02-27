using ShoppingStripe.Data.Entities;
using ShoppingStripe.Models;

namespace ShoppingStripe.Infrastructure;

public interface IProductsService
{
    List<ProductResponse> GetProductsAsync();
}