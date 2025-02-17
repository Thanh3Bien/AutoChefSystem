using System;
using System.Collections.Generic;

namespace AutoChefSystem.DAL.Entities;

public partial class Robot
{
    public int RobotId { get; set; }

    public int RobotTypeId { get; set; }

    public int LocationId { get; set; }

    public bool IsActive { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<RobotOperationLog> RobotOperationLogs { get; set; } = new List<RobotOperationLog>();

    public virtual RobotType RobotType { get; set; } = null!;
}
