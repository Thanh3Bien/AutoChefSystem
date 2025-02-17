using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Location
{
    public int LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Robot> Robots { get; set; } = new List<Robot>();
}
