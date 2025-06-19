using System.Collections.Generic;
using System.Threading.Tasks;
using SE171643.Repository.Entities;

namespace SE171643.Repository.Abstractions;

public interface IHandbagRepository
{
    Task<IEnumerable<Handbag>> GetAllAsync();
    Task<Handbag?> GetByIdAsync(int id);
    Task<Handbag> CreateAsync(Handbag handbag);
    Task<Handbag?> UpdateAsync(Handbag handbag);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Handbag>> SearchAsync(string? modelName, string? material);
} 