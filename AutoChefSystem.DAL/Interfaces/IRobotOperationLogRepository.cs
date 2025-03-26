﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Repositories.Interfaces
{
    public interface IRobotOperationLogRepository
    {
        Task<int> GetOrderCountByRobotAndDateAsync(int robotId);
        //Task<double?> GetAverageCompletionTimeByRobotAsync(int robotId);

    }
}
