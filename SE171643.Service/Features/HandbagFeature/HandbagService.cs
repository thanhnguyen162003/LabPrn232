using SE171643.Repository.Abstractions;
using SE171643.Repository.Entities;
using SE171643.Service.Abstractions;
using SE171643.Service.Models.HandbagModels;
using SE171643.Service.Models;

namespace SE171643.Service.Features.HandbagFeature;

public class HandbagService(IHandbagRepository handbagRepo, Summer2025HandbagDbContext context) : IHandbagService
{
    public async Task<IEnumerable<HandbagResponseModel>> GetAllAsync()
    {
        var handbags = await handbagRepo.GetAllAsync();
        return handbags.Select(h => new HandbagResponseModel
        {
            HandbagId = h.HandbagId,
            ModelName = h.ModelName,
            Material = h.Material,
            Color = h.Color,
            Price = h.Price,
            Stock = h.Stock,
            BrandId = h.BrandId,
            BrandName = h.Brand?.BrandName,
            BrandCountry = h.Brand?.Country
        });
    }

    public async Task<HandbagResponseModel?> GetByIdAsync(int id)
    {
        var h = await handbagRepo.GetByIdAsync(id);
        if (h == null) return null;
        return new HandbagResponseModel
        {
            HandbagId = h.HandbagId,
            ModelName = h.ModelName,
            Material = h.Material,
            Color = h.Color,
            Price = h.Price,
            Stock = h.Stock,
            BrandId = h.BrandId,
            BrandName = h.Brand?.BrandName,
            BrandCountry = h.Brand?.Country
        };
    }

    public async Task<ServiceResult<HandbagResponseModel>> CreateAsync(HandbagCreateRequest request)
    {
        var brand = await context.Brands.FindAsync(request.BrandId);
        if (brand == null)
            return ServiceResult<HandbagResponseModel>.Fail("HB40001", "Brand not found");
        var handbag = new Handbag
        {
            ModelName = request.ModelName,
            Material = request.Material,
            Price = request.Price,
            Stock = request.Stock,
            BrandId = request.BrandId
        };
        var created = await handbagRepo.CreateAsync(handbag);
        return ServiceResult<HandbagResponseModel>.Ok(new HandbagResponseModel
        {
            HandbagId = created.HandbagId,
            ModelName = created.ModelName,
            Material = created.Material,
            Color = created.Color,
            Price = created.Price,
            Stock = created.Stock,
            BrandId = created.BrandId,
            BrandName = brand.BrandName,
            BrandCountry = brand.Country
        });
    }

    public async Task<ServiceResult<HandbagResponseModel>> UpdateAsync(int id, HandbagUpdateRequest request)
    {
        var handbag = await handbagRepo.GetByIdAsync(id);
        if (handbag == null)
            return ServiceResult<HandbagResponseModel>.Fail("HB40401", "Handbag not found");
        var brand = await context.Brands.FindAsync(request.BrandId);
        if (brand == null)
            return ServiceResult<HandbagResponseModel>.Fail("HB40001", "Brand not found");
        handbag.ModelName = request.ModelName;
        handbag.Material = request.Material;
        handbag.Price = request.Price;
        handbag.Stock = request.Stock;
        handbag.BrandId = request.BrandId;
        handbag.Color = request.Color;
        var updated = await handbagRepo.UpdateAsync(handbag);
        return ServiceResult<HandbagResponseModel>.Ok(new HandbagResponseModel
        {
            HandbagId = updated!.HandbagId,
            ModelName = updated.ModelName,
            Material = updated.Material,
            Color = updated.Color,
            Price = updated.Price,
            Stock = updated.Stock,
            BrandId = updated.BrandId,
            BrandName = brand.BrandName,
            BrandCountry = brand.Country
        });
    }

    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {
        var deleted = await handbagRepo.DeleteAsync(id);
        if (!deleted)
            return ServiceResult<bool>.Fail("HB40401", "Handbag not found");
        return ServiceResult<bool>.Ok(true);
    }

    public async Task<IEnumerable<HandbagSearchGroupModel>> SearchAsync(string? modelName, string? material)
    {
        var result = await handbagRepo.SearchAsync(modelName, material);
        return result.GroupBy(h => h.Brand?.BrandName ?? "Unknown")
            .Select(g => new HandbagSearchGroupModel
            {
                BrandName = g.Key!,
                Handbags = g.Select(h => new HandbagResponseModel
                {
                    HandbagId = h.HandbagId,
                    ModelName = h.ModelName,
                    Material = h.Material,
                    Color = h.Color,
                    Price = h.Price,
                    Stock = h.Stock,
                    BrandId = h.BrandId,
                    BrandName = h.Brand?.BrandName,
                    BrandCountry = h.Brand?.Country
                }).ToList()
            });
    }
} 