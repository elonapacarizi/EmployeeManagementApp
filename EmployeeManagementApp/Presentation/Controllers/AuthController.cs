using EmployeeManagementApp.Domain.jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApp.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInfo loginInfo)
        {
            if (loginInfo.Username == "Admin" && loginInfo.Password == "admin")
            {
                var token = _jwtService.GenerateToken(loginInfo.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

       
    }

    public class LoginInfo
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
