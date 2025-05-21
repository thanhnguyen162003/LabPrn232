using Prn232.Lab2.Entities;
using Microsoft.EntityFrameworkCore;
namespace Prn232.Lab2.Data;

public static class DatabaseInit
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new Lab2DbContext(
            serviceProvider.GetRequiredService<DbContextOptions<Lab2DbContext>>());
        
        context.Database.EnsureCreated();

        if (context.Products.Any())
        {
            return;
        }
        var categories = new[]
        {
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Clothing" },
            new Category { CategoryId = 3, CategoryName = "Books" },
            new Category { CategoryId = 4, CategoryName = "Furniture" },
            new Category { CategoryId = 5, CategoryName = "Toys" }
        };
        var accountMembers = new[]
        {
            new AccountMember { MemberId = 1, MemberPassword = "password1", FullName = "John Doe", Email = "john.doe@example.com", MemberRole = "Admin" },
            new AccountMember { MemberId = 2, MemberPassword = "password2", FullName = "Jane Smith", Email = "jane.smith@example.com", MemberRole = "User" }
        };
        context.Categories.AddRange(categories);
        context.AccountMembers.AddRange(accountMembers);
        context.SaveChanges();
        
        var products = new[]
        {
            new Product
            {
                ProductName = "Laptop",
                UnitPrice = 1200.00m,
                UnitInStock = 10,
                CategoryId = 1
            },
            new Product
            {
                ProductName = "Smartphone",
                UnitPrice = 800.00m,
                UnitInStock = 20,
                CategoryId = 2
            },
            new Product
            {
                ProductName = "Headphones",
                UnitPrice = 150.00m,
                UnitInStock = 30,
                CategoryId = 3
            },
            new Product
            {
                ProductName = "Monitor",
                UnitPrice = 300.00m,
                UnitInStock = 15,
                CategoryId = 4
            },
            new Product
            {
                ProductName = "Keyboard",
                UnitPrice = 80.00m,
                UnitInStock = 25,
                CategoryId = 5
            }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
