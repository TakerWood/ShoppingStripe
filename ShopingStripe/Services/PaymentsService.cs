using ShoppingStripe.Infrastructure;
using ShoppingStripe.Models;
using Stripe;
using Stripe.Checkout;

namespace ShoppingStripe.Services;

public class PaymentsService : IPaymentsService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<PaymentsService> _logger;
    private readonly ICartService _cartService;
    
    public PaymentsService(IConfiguration configuration, ILogger<PaymentsService> logger, ICartService cartService)
    {
        _configuration = configuration;
        _logger = logger;
        _cartService = cartService;
    }

    public async Task<string> CreateCheckoutSession()
    {
        var cartItems = _cartService.GetCartItems();
        
        if (cartItems is null)
        {
            //todo add more info about order
            _logger.LogError($"Not correct items quantity");
            
            throw new Exception("Not correct items quantity");
        }

        var listItems = SessionLineItemOptionsList(cartItems);

        StripeConfiguration.ApiKey = _configuration["StripeConfiguration:SecretKey"];
        
        var options = new SessionCreateOptions
        {
            LineItems = listItems,
            Mode = "payment",
            SuccessUrl = "http://localhost:4242/success",
            CancelUrl = "http://localhost:4242/cancel",
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options);
        return session.Url;
    }

    private static List<SessionLineItemOptions>? SessionLineItemOptionsList(List<CartItem> cartItems)
    {
        var listItems = new List<SessionLineItemOptions>();

        foreach (var item in cartItems)
        {
            listItems?.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)item.Price,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = $"{item.ProductName}",
                    }
                },
                Quantity = item.Qty
            });
        }

        return listItems;
    }
}