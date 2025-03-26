using AutoChefSystem.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Interfaces
{
    public interface IDashboardService
    {
        //Task<List<Order>> GetSortedOrdersAsync(bool descending);

        Task<int> GetTodayOrderCountAsync();


        Task<Dictionary<string, int>> GetRecipeOrderCountsAsync();


        Task<double> GetAverageOrderCompletionTimeAsync();

        Task<int> GetOrderCountByRobotAndDateAsync(int robotId);

        //Task<double?> GetAverageCompletionTimeByRobotAsync(int robotId);

    }
}
