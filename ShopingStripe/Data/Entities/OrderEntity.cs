namespace ShoppingStripe.Data.Entities;

public class OrderEntity
{
    public Guid Id { get; set; }

    public int? Customerid { get; set; }

    public decimal? Totalamount { get; set; }

    public DateTime? Orderdate { get; set; }

    public int? Deliverytype { get; set; }

    public int? Paymenttype { get; set; }
}
