using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RobotOperationLog
{
    public class PaginatedRobotOperationLogResponse
    {
        public List<RobotOperationLogResponse> Logs { get; set; } = new List<RobotOperationLogResponse>();
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
