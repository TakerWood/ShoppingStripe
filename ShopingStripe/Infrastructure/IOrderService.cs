using ShoppingStripe.Models;

namespace ShoppingStripe.Infrastructure;

public interface IOrderService
{
    Task AddOrderAsync(OrderDetails customerDetails, CancellationToken cancellationToken);
}