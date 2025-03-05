using AutoChefSystem.BAL.Models.Roles;
using AutoChefSystem.BAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        private readonly ILogger<RoleController> _logger;
        public RoleController(RoleService roleService,
            ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        #region Get Role by Id
        /// <summary>
        /// Get a role based on Id in the system
        /// </summary>
        /// <param name="id">Id of the role you want to get</param>
        /// <returns>A role</returns>
        /// <response code="200">Return a role in the system</response>
        /// <response code="400">If the role is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _roleService.GetByIdAsync(id);
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
                ErrorMessage = "No role in data"
            });
        }
        #endregion
        #region Add new Role
        /// <summary>
        /// Add a new role
        /// </summary>
        /// <returns>A role was created</returns>
        /// <response code="200">A role was created</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateRoleRequest createRoleRequest)
        {
            try
            {
                var result = await _roleService.AddAsync(createRoleRequest);
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
        #region Get All Role
        /// <summary>
        /// Get All Role
        /// </summary>
        /// <returns>A role was created</returns>
        /// <response code="200">Return list roles</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _roleService.GetAllRolesAsync(pageNumber, pageSize);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving roles");
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }
        #endregion
    }
}
