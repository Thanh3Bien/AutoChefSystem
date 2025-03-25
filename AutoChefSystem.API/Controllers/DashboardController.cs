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

        [HttpGet("orders")]
        public async Task<IActionResult> GetSortedOrders([FromQuery] bool descending)
        {
            var orders = await _dashboardService.GetSortedOrdersAsync(descending);
            return Ok(orders);
        }

        [HttpGet("recipe-counts")]
        public async Task<IActionResult> GetRecipeOrderCounts()
        {
            var counts = await _dashboardService.GetRecipeOrderCountsAsync();
            return Ok(counts);
        }

        [HttpGet("average-time")]
        public async Task<IActionResult> GetAverageCompletionTime()
        {
            var avgTime = await _dashboardService.GetAverageOrderCompletionTimeAsync();
            return Ok(avgTime);
        }
    }
}
