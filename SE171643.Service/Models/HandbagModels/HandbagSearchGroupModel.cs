using System.Collections.Generic;

namespace SE171643.Service.Models.HandbagModels;

public class HandbagSearchGroupModel
{
    public string BrandName { get; set; } = null!;
    public List<HandbagResponseModel> Handbags { get; set; } = new();
} 