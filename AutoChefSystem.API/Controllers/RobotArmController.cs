//using AutoChefSystem.API.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//[Route("api/[controller]")]
//[ApiController]
//public class RobotArmController : ControllerBase
//{
//    private readonly IHttpClientFactory _httpClientFactory;
//    private readonly string _localApiUrl = "https://localhost:7247/api/RobotArmLocal/execute"; // Địa chỉ API cục bộ

//    public RobotArmController(IHttpClientFactory httpClientFactory)
//    {
//        _httpClientFactory = httpClientFactory;
//    }

//    [HttpPost("send-command")]
//    public async Task<IActionResult> SendCommand([FromBody] CommandRequestRobot request)
//    {
//        if (request == null || string.IsNullOrEmpty(request.Command))
//        {
//            return BadRequest("Invalid command request.");
//        }

//        // Tạo yêu cầu đến API cục bộ với HttpClientHandler để bỏ qua kiểm tra chứng chỉ
//        var handler = new HttpClientHandler
//        {
//            ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true // Bỏ qua kiểm tra chứng chỉ
//        };

//        var client = new HttpClient(handler);
//        var jsonContent = JsonConvert.SerializeObject(request);
//        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

//        var response = await client.PostAsync(_localApiUrl, content);

//        if (response.IsSuccessStatusCode)
//        {
//            var responseBody = await response.Content.ReadAsStringAsync();
//            return Ok(responseBody);
//        }
//        else
//        {
//            return StatusCode((int)response.StatusCode, "Error while sending command to local API.");
//        }
//    }
//}