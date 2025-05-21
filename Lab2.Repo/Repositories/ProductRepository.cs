using Lab2.Repo.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;
using Prn232.Lab2.Data;
using Prn232.Lab2.Entities;

namespace Lab2.Repo.Repositories;

public class ProductRepository(Lab2DbContext context) : IProductRepository
{
    public async Task<Product> CreateProduct(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }
        context.Products.Remove(product);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Product> GetProductById(int id)
    {
        return await context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync() ?? throw new Exception("Product not found");
    }

    public async Task<List<Product>> GetProducts()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
        return product;
    }
}
