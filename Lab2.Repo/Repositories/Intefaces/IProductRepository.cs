using Prn232.Lab2.Repo.Entities;
using System;

namespace Lab2.Repo.Repositories.Intefaces;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProductById(int id);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<bool> DeleteProduct(int id);
}
