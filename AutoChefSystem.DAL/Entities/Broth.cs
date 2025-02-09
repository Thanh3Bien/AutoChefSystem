using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Broth
{
    public int BrothsId { get; set; }

    public string BrothsName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
