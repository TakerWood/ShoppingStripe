namespace ShoppingStripe.Infrastructure;

public interface IPaymentsService
{
    Task<string> CreateCheckoutSession();
}