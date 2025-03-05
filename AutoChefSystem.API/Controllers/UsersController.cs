using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.Repositories.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        #region Get All User
        /// <summary>
        /// Get all user in the system with optional filtering and pagination.
        /// </summary>
        /// <param name="pageNumber">Current page number (default is 1)</param>
        /// <param name="pageSize">Number of user per page (default is 10)</param>
        /// <returns>A paginated list of user</returns>
        /// <response code="200">Returns paginated user</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No user found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var (users, totalRecords) = await _userService.GetAllAsync(pageNumber, pageSize);
                return Ok(new
                {
                    TotalRecords = totalRecords,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Users = users
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }
        #endregion

        #region Get User by Id
        /// <summary>
        /// Get User based on UserId in the system
        /// </summary>
        /// <param name="id">Id of user you want to get user</param>
        /// <returns>A user</returns>
        /// <response code="200">Return a user in the system</response>
        /// <response code="400">If the user is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _userService.GetByIdAsync(id);
                if (result is not null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return NotFound(new
            {
                ErrorMessage = "No user in data"
            });
        }
        #endregion

        #region Create New User
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="createUserRequest">The user details to create</param>
        /// <returns>The created user</returns>
        /// <response code="200">User created successfully</response>
        /// <response code="400">Invalid request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await _userService.AddAsync(createUserRequest);
                if (result is not null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return BadRequest();
        }
        #endregion

        #region Update User
        /// <summary>
        /// Update an existing user by ID.
        /// </summary>
        /// <param name="updateUserRequest">The updated user details</param>
        /// <returns>The updated user</returns>
        /// <response code="200">User updated successfully</response>
        /// <response code="404">User not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            try
            {
                var result = await _userService.UpdateAsync(updateUserRequest);
                if (result is not null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return BadRequest();
        }
        #endregion

        #region Delete User
        /// <summary>
        /// Delete a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns>User deleted successfully</returns>
        /// <response code="200">User deleted successfully</response>
        /// <response code="404">User not found</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
