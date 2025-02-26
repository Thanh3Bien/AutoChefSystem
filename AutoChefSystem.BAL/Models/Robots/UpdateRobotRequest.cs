using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.Robots
{
    public class UpdateRobotRequest
    {
        public int RobotTypeId { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }
    }
}
