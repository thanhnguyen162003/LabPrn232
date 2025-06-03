using System;

namespace Prn232.Lab2.Repo.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
