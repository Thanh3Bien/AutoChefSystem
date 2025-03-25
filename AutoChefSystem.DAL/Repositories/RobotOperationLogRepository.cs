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
using Microsoft.EntityFrameworkCore;

namespace AutoChefSystem.Repositories.Repositories
{
    public class RobotOperationLogRepository : GenericRepository<RobotOperationLog>, IRobotOperationLogRepository
    {
        public RobotOperationLogRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        { }
        public async Task<int> GetOrderCountByRobotAndDateAsync(int robotId, DateTime date)
        {
            return await _dbSet
                .Where(log => log.RobotId == robotId
                           && log.StartTime.Date == date.Date)
                .CountAsync();
        }


        public async Task<double?> GetAverageCompletionTimeByRobotAsync(int robotId)
        {
            var times = await _dbSet
                .Where(log => log.RobotId == robotId && log.EndTime != null)
                .Select(log => (double)(log.EndTime - log.StartTime).TotalSeconds)
                .ToListAsync();

            return times.Count > 0 ? times.Average() : (double?)null;
        }
    }
}
