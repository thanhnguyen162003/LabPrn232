namespace SE171643.Service.Models.HandbagModels;

public class HandbagResponseModel
{
    public int HandbagId { get; set; }
    public string ModelName { get; set; } = null!;
    public string? Material { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
    public int? Stock { get; set; }
    public int? BrandId { get; set; }
    public string? BrandName { get; set; }
    public string? BrandCountry { get; set; }
} 