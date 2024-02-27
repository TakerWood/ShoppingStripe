namespace ShoppingStripe.Data.Entities;

public class CustomerEntity
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateOnly? Datebirthday { get; set; }
}
