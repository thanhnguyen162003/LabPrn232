using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prn231.Lab1.Entities;

namespace Prn231.Lab1.Data;

public static class DatabaseInit
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
        
        context.Database.EnsureCreated();

        if (context.Products.Any())
        {
            return;
        }

        var products = new[]
        {
            new Product
            {
                Name = "Laptop",
                Price = 1200.00m,
                Quantity = 10,
                Description = "High-performance laptop with 16GB RAM",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Name = "Smartphone",
                Price = 800.00m,
                Quantity = 20,
                Description = "Latest smartphone model with 128GB storage",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Name = "Headphones",
                Price = 150.00m,
                Quantity = 30,
                Description = "Wireless noise-cancelling headphones",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Name = "Monitor",
                Price = 300.00m,
                Quantity = 15,
                Description = "27-inch 4K monitor",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Name = "Keyboard",
                Price = 80.00m,
                Quantity = 25,
                Description = "Mechanical gaming keyboard",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
