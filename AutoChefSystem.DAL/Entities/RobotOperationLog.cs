using System;
using System.Collections.Generic;

namespace AutoChefSystem.Repositories.Entities;

public partial class RobotOperationLog
{
    public int RobotOperationLogId { get; set; }

    public int OrderId { get; set; }

    public int RobotId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string CompletionStatus { get; set; } = null!;

    public string OperationLog { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual Robot Robot { get; set; } = null!;
}
