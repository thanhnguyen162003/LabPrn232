using System;

namespace Prn232.Lab2.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
