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
    }
}
