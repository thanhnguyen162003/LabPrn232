using Prn232.Lab2.Repo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2.Service.Features.Products;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
} 