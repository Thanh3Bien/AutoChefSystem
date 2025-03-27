using AutoChefSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IDashboardService
    {

        Task<int> GetOrderCountAsync(DateTime date);

        Task<Dictionary<string, int>> GetRecipeOrderCountsAsync(DateTime date);

        Task<double> GetAverageOrderCompletionTimeAsync(DateTime date);

        Task<int> GetOrderCountByRobotAndDateAsync(int robotId, DateTime date);

        Task<double?> GetAverageCompletionTimeByRobotAsync(int robotId, DateTime date);
    }
}
