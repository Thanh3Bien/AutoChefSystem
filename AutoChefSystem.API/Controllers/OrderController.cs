using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Infrastructures;
using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Order;
using AutoChefSystem.Services.Models.Recipe;
using AutoChefSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(OrderService orderService, ILogger<OrderController> logger)
        {
            _logger = logger;
            _orderService = orderService;
        }

        #region Create new order 
        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="createOrder">Details of the order to be created.</param>
        /// <returns>
        /// - Returns 200 OK with the created order details.<br/>
        /// - Returns 404 Not Found if there is an error during creation.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrder)
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
        /// <summary>
        /// Gets an order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order.</param>
        /// <returns>
        /// - Returns 200 OK with the order details.<br/>
        /// - Returns 404 Not Found if the order does not exist.
        /// </returns>
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
        /// <summary>
        /// Updates an existing order.
        /// </summary>
        /// <param name="updateOrder">The order details to update.</param>
        /// <returns>
        /// - Returns 200 OK with the updated order details.<br/>
        /// - Returns 404 Not Found if the order does not exist.<br/>
        /// - Returns 500 Internal Server Error if an unexpected error occurs.
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOrderRequest updateOrder)
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
        /// <returns>
        /// - Returns 200 OK with a paginated list of orders.<br/>
        /// - Returns 404 Not Found if no orders are found.<br/>
        /// - Returns 500 Internal Server Error if an unexpected error occurs.
        /// </returns>
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

        #region Change status Order 
        /// <summary>
        /// Updates the status of an order by its ID.
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to update.</param>
        /// <param name="isCancel">Set to true to cancel the order, false for other status updates.</param>
        /// <returns>
        /// - 200 OK: If the order status is successfully updated.<br/>
        /// - 400 Bad Request: If the update fails.
        /// </returns>
        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatus(int orderId , bool isCancel = false)
        {
            var result = await _orderService.UpdateOrderStatus(orderId, isCancel);
            if (result)
            {
                return Ok("Status updated successfully");
            }
            return BadRequest("Failed to update status");
        }
        #endregion

        #region Delete Order
        /// <summary>
        /// Sets the status of an order to "deleted" by its ID.
        /// </summary>
        /// <param name="id">The ID of the order to be deleted.</param>
        /// <returns>
        /// - Returns 200 OK if the order status is successfully updated to "deleted".<br/>
        /// - Returns 404 Not Found if the order does not exist.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (!result)
            {
                return NotFound(new { message = "Order not found." });
            }
            return Ok(new { message = "Order status set to deleted." });
        }
        #endregion
    }
}
