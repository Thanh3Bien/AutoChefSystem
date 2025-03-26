using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.RobotStepTask;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/robot-step-tasks")]
    [ApiController]
    public class RobotStepTaskController : ControllerBase
    {
        private readonly IRobotStepTaskService _service;

        public RobotStepTaskController(IRobotStepTaskService service)
        {
            _service = service;
        }

        #region Get All Robot Step Tasks
        /// <summary>
        /// Get all robot step tasks with pagination.
        /// </summary>
        /// <param name="pageNumber">Current page number (default = 1)</param>
        /// <param name="pageSize">Number of tasks per page (default = 10)</param>
        /// <returns>A paginated list of robot step tasks</returns>
        /// <response code="200">Returns a paginated list of tasks</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _service.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }
        #endregion

        #region Get Robot Step Task By Id
        /// <summary>
        /// Get a robot step task by its ID.
        /// </summary>
        /// <param name="id">The ID of the robot step task</param>
        /// <returns>A robot step task</returns>
        /// <response code="200">Returns the task</response>
        /// <response code="404">Task not found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound(new { message = "Task not found" });

            return Ok(result);
        }
        #endregion

        #region Create Robot Step Task
        /// <summary>
        /// Create a new robot step task.
        /// </summary>
        /// <param name="request">The task details to create</param>
        /// <returns>Success message</returns>
        /// <response code="200">Task created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRobotStepTaskRequest request)
        {
            await _service.CreateAsync(request);
            return Ok(new { message = "Created successfully" });
        }
        #endregion

        #region Update Robot Step Task
        /// <summary>
        /// Update an existing robot step task by ID.
        /// </summary>
        /// <param name="id">The ID of the robot step task</param>
        /// <param name="request">The updated task details</param>
        /// <returns>Success message</returns>
        /// <response code="200">Task updated successfully</response>
        /// <response code="404">Task not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateRobotStepTaskRequest request)
        {
            await _service.UpdateAsync(id, request);
            return Ok(new { message = "Updated successfully" });
        }
        #endregion

        #region Delete Robot Step Task
        /// <summary>
        /// Delete a robot step task by ID.
        /// </summary>
        /// <param name="id">The ID of the robot step task</param>
        /// <returns>Success message</returns>
        /// <response code="200">Task deleted successfully</response>
        /// <response code="404">Task not found</response>
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
