using AutoChefSystem.BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
           _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int id)
        {
            try
            {
                var result = await _roleService.GetById(id);
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
    }
}
