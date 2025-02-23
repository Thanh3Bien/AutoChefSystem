﻿
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
        /// <summary>
        /// Get all orders in the system with optional filtering, pagination, and sorting.
        /// </summary>
        /// <param name="page">Current page number (default is 1)</param>
        /// <param name="pageSize">Number of orders per page (default is 10)</param>
        /// <param name="status">Filter orders by status (optional)</param>
        /// <param name="sort">Sort orders by time: true for newest first, false for oldest first (default is true)</param>
        /// <returns>A paginated list of orders</returns>
        /// <response code="200">Returns the list of orders</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">No orders found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders(
            [FromQuery] string? status,
            [FromQuery] bool sort = true,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)

        {
            try
            {
                var result = await _orderService.GetAllOrdersAsync(sort, status, page, pageSize);

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
