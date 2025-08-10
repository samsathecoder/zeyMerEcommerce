using Microsoft.AspNetCore.Mvc;
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Dtos.User;
using ZeyMer.Domain.Entities;

namespace ZeyMer.API.Controller
{

    using Microsoft.AspNetCore.Mvc;
    using ZeyMer.Application.Helper;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto registerDto)
        {
            var user = await _userService.RegisterAsync(registerDto);
            return Ok(new
            {
                message = "User registered successfully",
                userId = user.Id
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = _userService.Authenticate(loginDto.Email, loginDto.Password);

            // JWT token oluştur
            if (user == null)
                return Unauthorized(new { message = "Email veya şifre hatalı" });

            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");
            var issuer = jwtSettings.GetValue<string>("Issuer");
            var audience = jwtSettings.GetValue<string>("Audience");

            var token = JwtHelper.GenerateToken(user, secretKey, issuer, audience);

            return Ok(new
            {
                token,
                expiration = DateTime.UtcNow.AddHours(2)
            });
        }
    }

}
