using AutoChefSystem.Services.Models.Notification;
using AutoChefSystem.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly PushNotificationService _pushNotificationService;

        public NotificationController(PushNotificationService pushNotificationService)
        {
            _pushNotificationService = pushNotificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.DeviceToken))
            {
                return BadRequest("Invalid request");
            }

            await _pushNotificationService.SendPushNotification(request.DeviceToken, request.Title, request.Message);
            return Ok("Notification sent successfully");
        }

    }
}
