using Microsoft.EntityFrameworkCore;
using ShoppingStripe.Data.Context;
using ShoppingStripe.Data.Entities;
using ShoppingStripe.Infrastructure;
using ShoppingStripe.Models;

namespace ShoppingStripe.Services;

public class OrderService : IOrderService
{
    private readonly MyDbContext _dbContext;
    private readonly ICartService _cartService;
    
    public OrderService(MyDbContext dbContext, ICartService cartService)
    {
        _dbContext = dbContext;
        _cartService = cartService;
    }

    public async Task AddOrderAsync(OrderDetails customerDetails, CancellationToken cancellationToken)
    {
        var customerItems = _cartService.GetCartItems();

        try
        {
            var userId = await GetOrderUserIdAsync(customerDetails, cancellationToken);
            var orderId = Guid.NewGuid();

            //todo if payment status decline ? needed change info 
            
            await _dbContext.Orders.AddAsync(new OrderEntity
            {
                Id = orderId,
                Customerid = userId,
                Totalamount = customerItems.Sum(x => x.Price * x.Qty),
                Deliverytype = (int)customerDetails.DeliveryType,
                Paymenttype = (int)customerDetails.PaymentType,
                Orderdate = DateTime.UtcNow
            }, cancellationToken);
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _dbContext.Products.AddRangeAsync(customerItems.Select(item => new ProductEntity
                {
                    Productid = item.ProductId,
                    Price = item.Price,
                    Quantity = item.Qty,
                    Totalamount = item.Price * item.Qty,
                    Orderid = orderId
                }).ToList(), cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<int> GetOrderUserIdAsync(OrderDetails customerDetails, CancellationToken cancellationToken)
    {
        if (!await _dbContext.Customers.AnyAsync(x => x.Datebirthday == customerDetails.Customer.Datebirthday,
                cancellationToken))
        {
            await _dbContext.Customers.AddAsync(customerDetails.Customer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        return await _dbContext.Customers.Where(x => x.Datebirthday == DateOnly.MaxValue)
            .Select(x => x.Id).FirstOrDefaultAsync(cancellationToken);
    }
}