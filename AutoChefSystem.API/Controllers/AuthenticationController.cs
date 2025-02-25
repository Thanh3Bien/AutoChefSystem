using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoChefSystem.BAL.Models.Users;
using AutoChefSystem.Repositories.Entities;
using AutoChefSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AutoChefSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IUserService userService,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _userService = userService;
        }
        [AllowAnonymous]

        [HttpPost("sign-in")]
        public async Task<IActionResult> LoginAsync(UserSingInRequest userSingInRequest)
        {
            try
            {
                var result = await _userService.LoginAsync(userSingInRequest.UserName, userSingInRequest.Password);
                if(result!=null)
                {
                    if (result.IsActive)
                    {
                        var accessToken = GenerateAccessToken(result);
                        return Ok(accessToken);
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            ErrorMessage = "This account has been deactivated. Please contact Admin for further information!"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NotFound(new
            {
                ErrorMessage = "Wrong UserName or Password"
            });
        }

        private string GenerateAccessToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.RoleName),
                new Claim("Id", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Key").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
