using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        #region Orders API

        /// <summary>
        /// Retrieves the number of orders placed today.
        /// </summary>
        /// <returns>The count of today's orders.</returns>
        [HttpGet("orders/today-count")]
        public async Task<IActionResult> GetTodayOrderCount()
        {
            var orderCount = await _dashboardService.GetTodayOrderCountAsync();
            return Ok(orderCount);
        }


        #endregion

        #region Recipe Order Counts API

        /// <summary>
        /// Retrieves the count of orders for each recipe.
        /// </summary>
        /// <returns>A dictionary containing recipe names as keys and their respective order counts as values.</returns>
        [HttpGet("recipe-counts")]
        public async Task<IActionResult> GetRecipeOrderCounts()
        {
            var counts = await _dashboardService.GetRecipeOrderCountsAsync();
            return Ok(counts);
        }

        #endregion

        #region Order Completion Time API

        /// <summary>
        /// Retrieves the average order completion time.
        /// </summary>
        /// <returns>The average time taken to complete an order.</returns>
        [HttpGet("average-time")]
        public async Task<IActionResult> GetAverageCompletionTime()
        {
            var avgTime = await _dashboardService.GetAverageOrderCompletionTimeAsync();
            return Ok(avgTime);
        }

        #endregion

        #region Robot Order Statistics API

        /// <summary>
        /// Retrieves the total number of orders completed by a robot on a given date.
        /// </summary>
        /// <param name="robotId">The ID of the robot.</param>
        /// <param name="date">The date for which the order count is requested.</param>
        /// <returns>The number of orders completed by the robot on the specified date.</returns>
        [HttpGet("robot/orders-count")]
        public async Task<IActionResult> GetRobotOrderCount([FromQuery] int robotId)
        {
            var count = await _dashboardService.GetOrderCountByRobotAndDateAsync(robotId);
            return Ok(count);
        }

        ///// <summary>
        ///// Retrieves the average completion time of orders for a specific robot.
        ///// </summary>
        ///// <param name="robotId">The ID of the robot.</param>
        ///// <returns>The average completion time for the robot's orders.</returns>
        //[HttpGet("robot/average-completion-time")]
        //public async Task<IActionResult> GetRobotAverageCompletionTime([FromQuery] int robotId)
        //{
        //    var avgTime = await _dashboardService.GetAverageCompletionTimeByRobotAsync(robotId);
        //    return Ok(avgTime);
        //}

        #endregion
    }
}
