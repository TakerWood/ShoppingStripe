namespace ShoppingStripe.Data.Entities;

public class ProductEntity
{
    public int Id { get; set; }

    public Guid? Orderid { get; set; }

    public decimal? Productid { get; set; }

    public decimal Price { get; set; }

    public decimal? Totalamount { get; set; }

    public decimal? Quantity { get; set; }
}
