//using Microsoft.AspNetCore.Mvc;
//using AutoChefSystem.Services.Services;
//using System.Threading.Tasks;

//namespace AutoChefSystem.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RobotArmLocalController : ControllerBase
//    {
//        private readonly RobotArmService _robotArmService;

//        public RobotArmLocalController(RobotArmService robotArmService)
//        {
//            _robotArmService = robotArmService;
//        }

//        [HttpPost("execute")]
//        public async Task<IActionResult> ExecuteCommand([FromBody] CommandRequestRobot request)
//        {
//            if (request == null || string.IsNullOrEmpty(request.Command))
//            {
//                return BadRequest("Invalid command request.");
//            }

//            //// Gọi dịch vụ để gửi lệnh
//            string response;
//            try
//            {
//                response = await _robotArmService.SendCommandAsync(request.Command);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Error while sending command: {ex.Message}");
//            }

//            return Ok(response);
//        }
//    }

//    public class CommandRequestRobot
//    {
//        public string Command { get; set; }
//    }
//}