using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Models.RobotType
{
    public class PaginatedRobotTypeResponse<T>
    {
        public List<T> RobotTypes { get; set; } = new();
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
