using System;
using System.Collections.Generic;

namespace AutoChefSystem.Repositories.Entities;

public partial class RobotStepTask
{
    public int StepTaskId { get; set; }

    public int StepId { get; set; }

    public string TaskDescription { get; set; } = null!;

    public int TaskOrder { get; set; }

    public TimeOnly EstimatedTime { get; set; }

    public int RepeatCount { get; set; }

    public virtual RecipeStep Step { get; set; } = null!;
}
