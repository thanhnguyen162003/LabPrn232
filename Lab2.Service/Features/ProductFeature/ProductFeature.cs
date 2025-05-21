
namespace Prn232.Lab2.Service.Features.ProductFeature;

public class ProductFeature(Lab2DbContext context) : IProductFeature
{
    public async Task<List<Product>> GetProducts()
    {
        // return await context.Products.ToListAsync();
        return new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Product 1", UnitPrice = 100, UnitInStock = 10 },
            new Product { ProductId = 2, ProductName = "Product 2", UnitPrice = 200, UnitInStock = 20 },
            new Product { ProductId = 3, ProductName = "Product 3", UnitPrice = 300, UnitInStock = 30 }
        };
    }
}
