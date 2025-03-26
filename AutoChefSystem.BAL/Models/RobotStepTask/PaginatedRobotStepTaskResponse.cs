using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RobotStepTask
{
    public class PaginatedRobotStepTaskResponse
    {
        public List<RobotStepTaskResponse> Tasks { get; set; } = new();
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
