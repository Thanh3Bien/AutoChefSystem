using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.RobotType;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/robot-types")]
    [ApiController]
    public class RobotTypeController : ControllerBase
    {
        private readonly IRobotTypeService _robotTypeService;

        public RobotTypeController(IRobotTypeService robotTypeService)
        {
            _robotTypeService = robotTypeService;
        }

        #region Get Robot Type by Id
        /// <summary>
        /// Get Robot Type based on Robot Type in the system
        /// </summary>
        /// <param name="id">Id of Robot type you want to get Robot Type</param>
        /// <returns>A role</returns>
        /// <response code="200">Return list Robot Type in the system</response>
        /// <response code="400">If the robot type is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _robotTypeService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get All Robot Type
        /// <summary>
        /// Get all robot type in the system with optional filtering and pagination.
        /// </summary>
        /// <param name="pageNumber">Current page number (default is 1)</param>
        /// <param name="pageSize">Number of robot type per page (default is 10)</param>
        /// <returns>A paginated list of robot type</returns>
        /// <response code="200">Returns paginated robot type</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No robot type found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _robotTypeService.GetAllAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Create New Robot Type
        /// <summary>
        /// Create a new Robot Type
        /// </summary>
        /// <param name="request">The Robot type details to create</param>
        /// <returns>The created robot type</returns>
        /// <response code="200">Robot type created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRobotTypeRequest request)
        {
            try
            {
                var response = await _robotTypeService.CreateAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update Robot Type
        /// <summary>
        /// Update an existing robot type by ID.
        /// </summary>
        /// <param name="request">The updated robot type details</param>
        /// <returns>The updated robot type</returns>
        /// <response code="200">Robot type updated successfully</response>
        /// <response code="404">Robot type not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateRobotTypeRequest request)
        {
            try
            {
                var response = await _robotTypeService.UpdateAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Delete Robot Type
        /// <summary>
        /// Delete a robot type by its ID.
        /// </summary>
        /// <param name="id">The ID of the robot type</param>
        /// <returns>Robot type deleted successfully</returns>
        /// <response code="200">Robot type deleted successfully</response>
        /// <response code="404">Robot type not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _robotTypeService.DeleteAsync(id);
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