using System;
using System.Collections.Generic;
using SE171643.Repository.Entities;

namespace SE171643.Repository.Entities;

public partial class SystemAccount
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Role { get; set; }

    public bool? IsActive { get; set; }

    public string? RoleName => Role.HasValue ? ((RoleEnum)Role.Value).GetRoleName() : null;
}
