using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoChefSystem.Services.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetOrderCountAsync(DateTime date)
        {
            return await _unitOfWork.Orders.GetOrderCountByDateAsync(date);
        }

        public async Task<Dictionary<string, int>> GetRecipeOrderCountsAsync(DateTime date)
        {
            return await _unitOfWork.Orders.GetRecipeOrderCountAsync(date);
        }

        public async Task<double> GetAverageOrderCompletionTimeAsync(DateTime date)
        {
            return (double)await _unitOfWork.Orders.GetAverageCompletionTimeAsync(date);
        }

        public async Task<int> GetOrderCountByRobotAndDateAsync(int robotId, DateTime date)
        {
            return await _unitOfWork.RobotOperations.GetOrderCountByRobotAndDateAsync(robotId, date);
        }

        public async Task<double?> GetAverageCompletionTimeByRobotAsync(int robotId, DateTime date)
        {
            return await _unitOfWork.RobotOperations.GetAverageCompletionTimeByRobotAsync(robotId, date);
        }
    }
}
