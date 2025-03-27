using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RobotOperationLog
{
    public class CreateRobotOperationLogRequest
    {
        public int OrderId { get; set; }
        public int RobotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CompletionStatus { get; set; } = null!;
        public string OperationLog { get; set; } = null!;
    }
}
