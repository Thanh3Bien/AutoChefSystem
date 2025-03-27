using AutoChefSystem.Services.Interfaces;
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
        /// Retrieves the number of orders placed on a specific date .
        /// </summary>
        /// <param name="date">The date to filter orders</param>
        /// <returns>The count of orders on the specified date.</returns>
        [HttpGet("orders/count")]
        public async Task<IActionResult> GetOrderCount([FromQuery] DateTime? date)
        {
            var targetDate = date ?? DateTime.UtcNow.Date;
            var orderCount = await _dashboardService.GetOrderCountAsync(targetDate);
            return Ok(orderCount);
        }

        #endregion

        #region Recipe Order Counts API

        /// <summary>
        /// Retrieves the count of orders for each recipe on a specific date .
        /// </summary>
        /// <param name="date">The date to filter recipe orders</param>
        /// <returns>A dictionary containing recipe names as keys and their respective order counts as values.</returns>
        [HttpGet("recipe-counts")]
        public async Task<IActionResult> GetRecipeOrderCounts([FromQuery] DateTime? date)
        {
            var targetDate = date ?? DateTime.UtcNow.Date;
            var counts = await _dashboardService.GetRecipeOrderCountsAsync(targetDate);
            return Ok(counts);
        }

        #endregion

        #region Order Completion Time API

        /// <summary>
        /// Retrieves the average order completion time on a specific date .
        /// </summary>
        /// <param name="date">The date to filter average completion time .</param>
        /// <returns>The average time taken to complete an order.</returns>
        [HttpGet("average-time")]
        public async Task<IActionResult> GetAverageCompletionTime([FromQuery] DateTime? date)
        {
            var targetDate = date ?? DateTime.UtcNow.Date;
            var avgTime = await _dashboardService.GetAverageOrderCompletionTimeAsync(targetDate);
            return Ok(avgTime);
        }

        #endregion

        #region Robot Order Statistics API

        /// <summary>
        /// Retrieves the total number of orders completed by a robot on a given date .
        /// </summary>
        /// <param name="robotId">The ID of the robot.</param>
        /// <param name="date">The date for which the order count is requested .</param>
        /// <returns>The number of orders completed by the robot on the specified date.</returns>
        [HttpGet("robot/orders-count")]
        public async Task<IActionResult> GetRobotOrderCount([FromQuery] int robotId, [FromQuery] DateTime? date)
        {
            var targetDate = date ?? DateTime.UtcNow.Date;
            var count = await _dashboardService.GetOrderCountByRobotAndDateAsync(robotId, targetDate);
            return Ok(count);
        }

        /// <summary>
        /// Retrieves the average completion time of orders for a specific robot on a given date.
        /// </summary>
        /// <param name="robotId">The ID of the robot.</param>
        /// <param name="date">The date to filter.</param>
        /// <returns>The average completion time for the robot's orders.</returns>
        [HttpGet("robot/average-completion-time")]
        public async Task<IActionResult> GetRobotAverageCompletionTime([FromQuery] int robotId, [FromQuery] DateTime? date)
        {
            var targetDate = date ?? DateTime.UtcNow.Date;
            var avgTime = await _dashboardService.GetAverageCompletionTimeByRobotAsync(robotId, targetDate);
            return Ok(avgTime);
        }

        #endregion
    }
}
