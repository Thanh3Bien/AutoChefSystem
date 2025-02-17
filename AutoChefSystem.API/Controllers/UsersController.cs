using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.BAL.Services;
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

        
    }
}
