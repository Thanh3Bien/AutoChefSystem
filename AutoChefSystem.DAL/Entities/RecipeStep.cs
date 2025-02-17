using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class RecipeStep
{
    public int StepId { get; set; }

    public int RecipeId { get; set; }

    public string StepDescription { get; set; } = null!;

    public int StepNumber { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

    public virtual ICollection<StepTask> StepTasks { get; set; } = new List<StepTask>();
}
