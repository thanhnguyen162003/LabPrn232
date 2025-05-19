using System;

namespace Prn232.Lab2.Entities;

public class Product
{
    public int ProductId { get; set; }
    public required string ProductName { get; set; }
    public int CategoryId { get; set; }
    public required decimal UnitPrice { get; set; }
    public required int UnitInStock { get; set; }
    public virtual Category? Category { get; set; }
}
