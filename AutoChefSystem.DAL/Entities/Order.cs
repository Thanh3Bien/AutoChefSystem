using System;
using System.Collections.Generic;

namespace AutoChefSystem.Repositories.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int RecipeId { get; set; }

    public int LocationId { get; set; }

    public int RobotId { get; set; }

    public DateTime OrderedTime { get; set; }

    public DateTime? CompletedTime { get; set; }

    public string Status { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;

    public virtual Robot Robot { get; set; } = null!;

    public virtual ICollection<RobotOperationLog> RobotOperationLogs { get; set; } = new List<RobotOperationLog>();
}
