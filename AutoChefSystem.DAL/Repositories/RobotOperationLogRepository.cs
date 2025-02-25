using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoChefSystem.Repositories;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoChefSystem.Repositories.Repositories
{
    public class RobotOperationLogRepository : GenericRepository<RobotOperationLog>, IRobotOperationLogRepository
    {
        public RobotOperationLogRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        {
        }
    }
}
