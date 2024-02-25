using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace PaymentTest.Controllers;

public class PaymentsService : Controller
{
    private readonly IConfiguration _configuration;
    
    public PaymentsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [Route("api/payments/createCheckout")]
    public async Task<ActionResult<string>> CreateCheckoutSession()
    {
        StripeConfiguration.ApiKey = _configuration["StripeConfiguration:SecretKey"];
        
        var options = new SessionCreateOptions
        {
            LineItems = new List<SessionLineItemOptions>
            {
                new()
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = 2000,
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "T-shirt",
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = "http://localhost:4242/success",
            CancelUrl = "http://localhost:4242/cancel",
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options);
        return Ok(session.Url);
    }
}