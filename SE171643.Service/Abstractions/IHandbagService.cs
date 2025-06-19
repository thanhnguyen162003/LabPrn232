using SE171643.Service.Models;
using SE171643.Service.Models.HandbagModels;


namespace SE171643.Service.Abstractions;

public interface IHandbagService
{
    Task<IEnumerable<HandbagResponseModel>> GetAllAsync();
    Task<HandbagResponseModel?> GetByIdAsync(int id);
    Task<ServiceResult<HandbagResponseModel>> CreateAsync(HandbagCreateRequest request);
    Task<ServiceResult<HandbagResponseModel>> UpdateAsync(int id, HandbagUpdateRequest request);
    Task<ServiceResult<bool>> DeleteAsync(int id);
    Task<IEnumerable<HandbagSearchGroupModel>> SearchAsync(string? modelName, string? material);
} 