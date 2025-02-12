using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Dish
{
    public int DishId { get; set; }

    public string DishName { get; set; } = null!;

    public int? NoodlesId { get; set; }

    public int? BrothsId { get; set; }

    public virtual Broth? Broths { get; set; }

    public virtual Noodle? Noodles { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
