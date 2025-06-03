using Lab2.Repo.Repositories.Intefaces;
using Prn232.Lab2.Commons.Intefaces;
using Prn232.Lab2.Repo.Entities;

namespace Prn232.Lab2.Service.Features.ProductFeature;

public class ProductFeature(IProductRepository productRepository) : IProductFeature
{
    public async Task<Product> CreateProduct(Product product)
    {
        return await productRepository.CreateProduct(product);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        return await productRepository.DeleteProduct(id);
    }

    public async Task<Product> GetProductById(int id)
    {
        return await productRepository.GetProductById(id);
    }

    public async Task<List<Product>> GetProducts()
    {
        return await productRepository.GetProducts();
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        return await productRepository.UpdateProduct(product);
    }
}
