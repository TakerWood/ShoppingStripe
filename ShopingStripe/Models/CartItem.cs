namespace ShoppingStripe.Models;

public class CartItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal TotalAmount { get; set; }
}