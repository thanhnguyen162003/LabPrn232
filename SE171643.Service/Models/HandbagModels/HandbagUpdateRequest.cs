using System.ComponentModel.DataAnnotations;

namespace SE171643.Service.Models.HandbagModels;

public class HandbagUpdateRequest
{
    [Required]
    [RegularExpression(@"^([A-Z0-9][a-zA-Z0-9#]*\s)*([A-Z0-9][a-zA-Z0-9#]*)$")]
    public string ModelName { get; set; } = null!;

    [Required]
    public string Material { get; set; } = null!;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(1, int.MaxValue)]
    public int Stock { get; set; }

    [Required]
    public int BrandId { get; set; }

    public string? Color { get; set; }
} 