using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.RobotOperationLog;
using AutoChefSystem.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/robot-operation-logs")]
    [ApiController]
    public class RobotOperationLogController : ControllerBase
    {
        private readonly IRobotOperationLogService _service;

        public RobotOperationLogController(IRobotOperationLogService service)
        {
            _service = service;
        }

        #region Get All Logs
        /// <summary>
        /// Get all robot operation logs with pagination.
        /// </summary>
        /// <param name="pageNumber">Current page number (default = 1)</param>
        /// <param name="pageSize">Number of logs per page (default = 10)</param>
        /// <returns>A paginated list of robot operation logs</returns>
        /// <response code="200">Returns a paginated list of logs</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _service.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }
        #endregion

        #region Get Logs By Order Id
        /// <summary>
        /// Get robot operation logs by OrderId.
        /// </summary>
        /// <param name="orderId">The OrderId to filter logs</param>
        /// <returns>A list of robot operation logs</returns>
        /// <response code="200">Returns a list of logs</response>
        /// <response code="404">Logs not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrderIdAsync(int orderId)
        {
            var result = await _service.GetByOrderIdAsync(orderId);
            if (result == null)
                return NotFound(new { message = "Order not found" });

            return Ok(result);
        }
        #endregion

        #region Get Log By Id
        /// <summary>
        /// Get a robot operation log by its ID.
        /// </summary>
        /// <param name="id">The ID of the robot operation log</param>
        /// <returns>A robot operation log</returns>
        /// <response code="200">Returns the log</response>
        /// <response code="404">Log not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound(new { message = "Log not found" });

            return Ok(result);
        }
        #endregion

        #region Create Log
        /// <summary>
        /// Create a new robot operation log.
        /// </summary>
        /// <param name="request">The log details to create</param>
        /// <returns>The created log</returns>
        /// <response code="200">Log created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRobotOperationLogRequest request)
        {
            try
            {
                var response = await _service.CreateAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

        #region Update Log
        /// <summary>
        /// Update an existing robot operation log by ID.
        /// </summary>
        /// <param name="id">The ID of the robot operation log</param>
        /// <param name="request">The updated log details</param>
        /// <returns>The updated log</returns>
        /// <response code="200">Log updated successfully</response>
        /// <response code="404">Log not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateRobotOperationLogRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            if (result == null)
                return NotFound(new { message = "Log not found" });

            return Ok(result);
        }
        #endregion

        #region Delete Log
        /// <summary>
        /// Delete a robot operation log by ID.
        /// </summary>
        /// <param name="id">The ID of the robot operation log</param>
        /// <returns>Success message</returns>
        /// <response code="200">Log deleted successfully</response>
        /// <response code="404">Log not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _service.DeleteAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion
    }
}


