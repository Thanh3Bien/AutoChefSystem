using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string RecipeName { get; set; } = null!;

    public string Ingredients { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
}
