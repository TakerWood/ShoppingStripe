using ShoppingStripe.Data.Entities;
using ShoppingStripe.Models.Enums;

namespace ShoppingStripe.Models;

public class OrderDetails
{
    public CustomerEntity Customer { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public PaymentType PaymentType { get; set; }
}