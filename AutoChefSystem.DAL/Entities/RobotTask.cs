using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class RobotTask
{
    public int RobotTaskId { get; set; }

    public string RobotTaskName { get; set; } = null!;

    public string TaskDescription { get; set; } = null!;

    public TimeOnly EstimatedTime { get; set; }

    public virtual ICollection<StepTask> StepTasks { get; set; } = new List<StepTask>();
}
