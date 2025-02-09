using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string Name { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public bool IsActive { get; set; }
}
