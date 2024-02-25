namespace PaymentTest.Data.Entities;

public partial class OrderEntity
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? OrderDate { get; set; }
}
