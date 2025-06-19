using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SE171643.Repository.Abstractions;
using SE171643.Repository.Entities;

namespace SE171643.Repository.Repositories;

public class HandbagRepository(Summer2025HandbagDbContext context) : IHandbagRepository
{
    public async Task<IEnumerable<Handbag>> GetAllAsync()
        => await context.Handbags.Include(h => h.Brand).ToListAsync();

    public async Task<Handbag?> GetByIdAsync(int id)
        => await context.Handbags.Include(h => h.Brand).FirstOrDefaultAsync(h => h.HandbagId == id);

    public async Task<Handbag> CreateAsync(Handbag handbag)
    {
        context.Handbags.Add(handbag);
        await context.SaveChangesAsync();
        return handbag;
    }

    public async Task<Handbag?> UpdateAsync(Handbag handbag)
    {
        var existing = await context.Handbags.FindAsync(handbag.HandbagId);
        if (existing == null) return null;
        context.Entry(existing).CurrentValues.SetValues(handbag);
        await context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var handbag = await context.Handbags.FindAsync(id);
        if (handbag == null) return false;
        context.Handbags.Remove(handbag);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Handbag>> SearchAsync(string? modelName, string? material)
    {
        var query = context.Handbags.Include(h => h.Brand).AsQueryable();
        if (!string.IsNullOrWhiteSpace(modelName))
            query = query.Where(h => h.ModelName.Contains(modelName));
        if (!string.IsNullOrWhiteSpace(material))
            query = query.Where(h => h.Material != null && h.Material.Contains(material));
        return await query.ToListAsync();
    }
} 