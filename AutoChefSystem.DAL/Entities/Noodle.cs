using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Noodle
{
    public int NoodlesId { get; set; }

    public string NoodlesName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
