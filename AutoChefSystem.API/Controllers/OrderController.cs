
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

        #region Create new order 
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

        #region Get Order By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound(new { message = $"Order with ID {id} not found." });
            }
            return Ok(order);
        }


        #endregion

        #region Update Order
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOrderRequest updateOrder )
        {
            try
            {
                var result = await _orderService.UpdateAsync(updateOrder);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

        #endregion

        #region Get All Order 
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders([FromQuery] string? status, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {

            try
            {
                var result = await _orderService.GetAllOrdersAsync(status, page, pageSize);

                if (result is not null)
                {
                    return Ok(result);
                }

                return NotFound(new
                {
                    ErrorMessage = "No order found in the database."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching order.");
                return StatusCode(500, new { ErrorMessage = "An unexpected error occurred. Please try again later." });
            }
        }
        #endregion




    }
}
