
﻿using Microsoft.EntityFrameworkCore;
﻿using AutoChefSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRobotOperationLogRepository
    {
        Task<int> GetOrderCountByRobotAndDateAsync(int robotId, DateTime date);
        Task<double?> GetAverageCompletionTimeByRobotAsync(int robotId, DateTime date);

        Task<IEnumerable<RobotOperationLog>> GetAllAsync(int pageNumber, int pageSize);
        Task<List<RobotOperationLog>> GetByOrderIdAsync(int orderId);
        Task<RobotOperationLog> CreateAsync(RobotOperationLog log);
        Task<RobotOperationLog?> UpdateAsync(int id, RobotOperationLog log);
        Task<bool> DeleteAsync(int id);
        Task<RobotOperationLog?> GetByIdAsync(int id);
    }
}
