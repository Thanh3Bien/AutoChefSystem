using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RobotStepTask
{
    public class CreateRobotStepTaskRequest
    {
        public int StepTaskId { get; set; }
        public int StepId { get; set; }
        public string TaskDescription { get; set; } = null!;
        public int TaskOrder { get; set; }
        public string EstimatedTime { get; set; }
        public int RepeatCount { get; set; }
    }
}
