using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RobotType
{
    public class CreateRobotTypeRequest
    {
        public string RobotTypeName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
