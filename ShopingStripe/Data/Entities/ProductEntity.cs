﻿namespace ShoppingStripe.Data.Entities;

public class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Imageurl { get; set; }
}