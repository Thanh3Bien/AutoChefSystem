using System;
using System.Collections.Generic;

namespace AutoChefSystem.Repositories.Entities;

public partial class RecipeStep
{
    public int StepId { get; set; }

    public int RecipeId { get; set; }

    public string StepDescription { get; set; } = null!;

    public int StepNumber { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

    public virtual ICollection<RobotStepTask> RobotStepTasks { get; set; } = new List<RobotStepTask>();
}
