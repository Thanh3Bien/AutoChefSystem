
using AutoChefSystem.DAL.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Order;
using AutoChefSystem.Services.Models.Recipe;
using AutoChefSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(OrderService orderService, ILogger<OrderController> logger )
        { 
            _logger = logger;
            _orderService = orderService;
        }

        #region
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrder )
        {

            var result = await _orderService.CreateOrderAsync(createOrder);

            if (result == null)
            {
                return NotFound(new { message = $"Error when create new recipe " });
            }
            return Ok(result);
        }

        #endregion

    }
}
