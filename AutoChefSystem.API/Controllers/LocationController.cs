using AutoChefSystem.Services.Interfaces;
using AutoChefSystem.Services.Models.Location;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        #region Get Location by Id
        /// <summary>
        /// Get location based on LocationId in the system
        /// </summary>
        /// <param name="id">Id of location you want to get location</param>
        /// <returns>A location</returns>
        /// <response code="200">Return a location in the system</response>
        /// <response code="400">If the location is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _locationService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

        #region Get All Location
        /// <summary>
        /// Get all location in the system with optional filtering and pagination.
        /// </summary>
        /// <param name="pageNumber">Current page number (default is 1)</param>
        /// <param name="pageSize">Number of robot per page (default is 10)</param>
        /// <returns>A paginated list of location</returns>
        /// <response code="200">Returns paginated location</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No robot found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _locationService.GetAllAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

        #region Create New Location
        /// <summary>
        /// Create a new location.
        /// </summary>
        /// <param name="request">The location details to create</param>
        /// <returns>Location created successfully</returns>
        /// <response code="200">Location created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateLocationRequest request)
        {
            try
            {
                var response = await _locationService.CreateAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

        #region Update Location
        /// <summary>
        /// Update an existing location by ID.
        /// </summary>
        /// <param name="request">The updated location details</param>
        /// <returns>The updated location</returns>
        /// <response code="200">Location updated successfully</response>
        /// <response code="404">Location not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateLocationRequest request)
        {
            try
            {
                var response = await _locationService.UpdateAsync(id, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        #endregion

        #region Delete Location
        /// <summary>
        /// Delete a location by its ID.
        /// </summary>
        /// <param name="id">The ID of the location</param>
        /// <returns>Location deleted successfully</returns>
        /// <response code="200">Location deleted successfully</response>
        /// <response code="404">Location not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var response = await _locationService.DeleteAsync(id);
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
