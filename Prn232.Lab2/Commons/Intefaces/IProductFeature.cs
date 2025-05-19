using System;
using Prn232.Lab2.Entities;

namespace Prn232.Lab2.Commons.Intefaces;

public interface IProductFeature
{
    Task<List<Product>> GetProducts();
}
