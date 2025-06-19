using System;
using System.Collections.Generic;

namespace SE171643.Repository.Entities;

public partial class Handbag
{
    public int HandbagId { get; set; }

    public int? BrandId { get; set; }

    public string ModelName { get; set; } = null!;

    public string? Material { get; set; }

    public string? Color { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public virtual Brand? Brand { get; set; }
}
