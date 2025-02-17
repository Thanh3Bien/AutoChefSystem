using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class StepTask
{
    public int StepTaskId { get; set; }

    public int TaskId { get; set; }

    public int StepId { get; set; }

    public int TaskOrder { get; set; }

    public virtual RecipeStep Step { get; set; } = null!;

    public virtual RobotTask Task { get; set; } = null!;
}
