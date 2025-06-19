using System;
using System.Collections.Generic;

namespace SE171643.Repository.Entities;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public string? Country { get; set; }

    public int? FoundedYear { get; set; }

    public string? Website { get; set; }

    public virtual ICollection<Handbag> Handbags { get; set; } = new List<Handbag>();
}
