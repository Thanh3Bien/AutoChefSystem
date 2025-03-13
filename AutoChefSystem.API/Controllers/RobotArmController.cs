using AutoChefSystem.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotArmController : ControllerBase
    {
        private readonly RobotArmService _robotArmService;

        public RobotArmController(RobotArmService robotArmService)
        {
            _robotArmService = robotArmService;
        }

        [HttpPost("command")]
        public async Task<IActionResult> SendCommand([FromBody] CommandRequestRobot request)
        {
            var result = await _robotArmService.SendCommandAsync(request.Command);
            return Ok(result);
        }
    }

    public class CommandRequestRobot
    {
        public string Command { get; set; }
    }
}
