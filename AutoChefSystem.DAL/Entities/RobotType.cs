using System;
using System.Collections.Generic;

namespace AutoChefSystem.Repositories.Entities;

public partial class RobotType
{
    public int RobotTypeId { get; set; }

    public string RobotTypeName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Robot> Robots { get; set; } = new List<Robot>();
}
