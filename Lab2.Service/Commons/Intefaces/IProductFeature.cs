
using Prn232.Lab2.Repo.Entities;

namespace Prn232.Lab2.Commons.Intefaces;

public interface IProductFeature
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProductById(int id);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<bool> DeleteProduct(int id);
}
