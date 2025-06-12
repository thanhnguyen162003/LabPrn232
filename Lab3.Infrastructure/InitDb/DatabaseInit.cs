using Lab3.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Prn232.Lab3.InitDb;

public static class DatabaseInit
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<Lab3DbContext>();
        
        // Ensure database is created and migrations are applied
        context.Database.EnsureDeleted(); // This will delete the database if it exists
        context.Database.EnsureCreated(); // This will create the database and all tables

        // First, seed Categories
        if (!context.Categories.Any())
        {
            var categories = new[]
            {
                new Category { CategoryName = "Electronics" },
                new Category { CategoryName = "Clothing" },
                new Category { CategoryName = "Books" },
                new Category { CategoryName = "Furniture" },
                new Category { CategoryName = "Toys" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        // Then, seed Products
        if (!context.Products.Any())
        {
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

        // Finally, seed AccountMembers
        if (!context.AccountMembers.Any())
        {
            var accountMembers = new[]
            {
                new AccountMember { MemberPassword = "password1", FullName = "John Doe", Email = "john.doe@example.com", MemberRole = "Admin" },
                new AccountMember { MemberPassword = "password2", FullName = "Jane Smith", Email = "jane.smith@example.com", MemberRole = "User" }
            };
            
            context.AccountMembers.AddRange(accountMembers);
            context.SaveChanges();
        }
    }
}
