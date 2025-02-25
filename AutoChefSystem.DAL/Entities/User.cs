using System;
using System.Collections.Generic;

namespace AutoChefSystem.Repositories.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public bool IsActive { get; set; }

    public string? UserFullName { get; set; }

    public string? Image { get; set; }

    public virtual Role? Role { get; set; }
}
