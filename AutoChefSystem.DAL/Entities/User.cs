using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? RoleId { get; set; }

    public bool IsActive { get; set; }

    public virtual Role? Role { get; set; }
}
