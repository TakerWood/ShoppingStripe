namespace ShoppingStripe.Data.Entities;

public partial class CustomerEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateBirthday { get; set; }
}
