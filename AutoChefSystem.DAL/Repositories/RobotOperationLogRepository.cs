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

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoChefSystem.Repositories.Repositories
{
    public class RobotOperationLogRepository : GenericRepository<RobotOperationLog>, IRobotOperationLogRepository
    {
        public RobotOperationLogRepository(
        AutoChefSystemContext context,
        ILogger logger) : base(context, logger)
        { }
        public async Task<int> GetOrderCountByRobotAndDateAsync(int robotId)
        {

            var today = DateTime.Today;

            return await _dbSet
                .Where(log => log.RobotId == robotId && log.StartTime.Date == today)
                .Select(log => log.OrderId)  
                .Distinct()  
                .CountAsync();  
        }



        //public async Task<double?> GetAverageCompletionTimeByRobotAsync(int robotId)
        //{
        //    var times = await _dbSet
        //        .Where(log => log.RobotId == robotId && log.EndTime != null)
        //        .Select(log => (double)(log.EndTime - log.StartTime).TotalSeconds)
        //        .ToListAsync();

        //    return times.Count > 0 ? times.Average() : (double?)null;
        //}

        public async Task<IEnumerable<RobotOperationLog>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.RobotOperationLogs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<RobotOperationLog>> GetByOrderIdAsync(int orderId)
        {
            return await _context.RobotOperationLogs
                .Where(log => log.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<RobotOperationLog> CreateAsync(RobotOperationLog log)
        {
            _context.RobotOperationLogs.Add(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<RobotOperationLog?> UpdateAsync(int id, RobotOperationLog log)
        {
            var existingLog = await _context.RobotOperationLogs.FindAsync(log.RobotOperationLogId);
            if (existingLog == null) return null;

            existingLog.OrderId = log.OrderId;
            existingLog.RobotId = log.RobotId;
            existingLog.StartTime = log.StartTime;
            existingLog.EndTime = log.EndTime;
            existingLog.CompletionStatus = log.CompletionStatus;
            existingLog.OperationLog = log.OperationLog;
            _context.RobotOperationLogs.Update(existingLog);
            await _context.SaveChangesAsync();
            return existingLog;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var log = await _context.RobotOperationLogs.FindAsync(id);
            if (log == null) return false;

            _context.RobotOperationLogs.Remove(log);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<RobotOperationLog?> GetByIdAsync(int id)
        {
            return await _context.RobotOperationLogs.FindAsync(id);
        }
    }
}
