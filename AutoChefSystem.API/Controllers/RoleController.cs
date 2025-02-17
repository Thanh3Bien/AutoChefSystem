using AutoChefSystem.BAL.Models.Roles;
using AutoChefSystem.BAL.Services;
using AutoChefSystem.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
           _roleService = roleService;
        }

        [HttpGet]
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

    }
}
