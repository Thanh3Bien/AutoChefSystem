using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoChefSystem.Services.Services
{
    
   public class DashboardService:IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

        }


        //public async Task<List<Order>> GetSortedOrdersAsync(bool descending)
        //{
        //    return await _unitOfWork.Orders.GetOrdersSortedByTimeAsync(descending);
 
        //}

        public async Task<Dictionary<string, int>> GetRecipeOrderCountsAsync()
        {
            return await _unitOfWork.Orders.GetRecipeOrderCountAsync();
        }

        public async Task<double> GetAverageOrderCompletionTimeAsync()
        {
            return (double)await _unitOfWork.Orders.GetAverageCompletionTimeAsync();
        }

        public async Task<int> GetOrderCountByRobotAndDateAsync(int robotId)
        {
            return await _unitOfWork.RobotOperations.GetOrderCountByRobotAndDateAsync(robotId);
        }

        //public async Task<double?> GetAverageCompletionTimeByRobotAsync(int robotId)
        //{
        //    return await _unitOfWork.RobotOperations.GetAverageCompletionTimeByRobotAsync(robotId);
        //}

        public async Task<int> GetTodayOrderCountAsync()
        {
            return await _unitOfWork.Orders.GetTodayOrderCountAsync();

        }
    }
}
