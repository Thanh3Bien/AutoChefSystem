using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Robots;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        private readonly IRobotService _robotService;

        public RobotsController(IRobotService robotService)
        {
            _robotService = robotService;
        }

        #region Get Robot by Id
        /// <summary>
        /// Get Robot based on RobotId in the system
        /// </summary>
        /// <param name="id">Id of Robot you want to get Robot</param>
        /// <returns>A robot</returns>
        /// <response code="200">Return a robot in the system</response>
        /// <response code="400">If the Robot is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _robotService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get All Robot
        /// <summary>
        /// Get all robot in the system with optional filtering and pagination.
        /// </summary>
        /// <param name="pageNumber">Current page number (default is 1)</param>
        /// <param name="pageSize">Number of robot per page (default is 10)</param>
        /// <returns>A paginated list of robot</returns>
        /// <response code="200">Returns paginated robot</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No robot found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _robotService.GetAllAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Create New Robot
        /// <summary>
        /// Create a new Robot.
        /// </summary>
        /// <param name="request">The Robot details to create</param>
        /// <returns>The created robot</returns>
        /// <response code="200">Robot created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRobotRequest request)
        {
            try
            {
                var response = await _robotService.CreateAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Robot
        /// <summary>
        /// Update an existing robot by ID.
        /// </summary>
        /// <param name="request">The updated robot details</param>
        /// <returns>The updated robot</returns>
        /// <response code="200">Robot updated successfully</response>
        /// <response code="404">Robot not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateRobotRequest request)
        {
            try
            {
                var response = await _robotService.UpdateAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Delete Robot
        /// <summary>
        /// Delete a robot by its ID.
        /// </summary>
        /// <param name="id">The ID of the robot</param>
        /// <returns>Robot deleted successfully</returns>
        /// <response code="200">Robot deleted successfully</response>
        /// <response code="404">Robot not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _robotService.DeleteAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
