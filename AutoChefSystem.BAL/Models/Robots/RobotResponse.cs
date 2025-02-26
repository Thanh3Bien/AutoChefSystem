using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.Robots
{
    public class RobotResponse
    {
        public int RobotId { get; set; }
        public int RobotTypeId { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }
        public string RobotTypeName { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;
    }
}
