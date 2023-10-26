using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Service.IServices;

namespace wellness.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(UserRegisterRequest request)
        {
            var response = await _authService.RegisterUser(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(UserLoginRequest request)
        {


            var response = await _authService.Login(request);

            if (response.Success)
            {
                if (request.Desktop && !response.Message.Equals("3"))
                    return Ok(response);
                if (!request.Desktop && response.Message.Equals("3"))
                    return Ok(response);

            }

            return BadRequest(response.Message);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var response = await _authService.RefreshToken();
            if (response.Success)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet, Authorize(Roles = "Administrator")]
        public ActionResult<string> Aloha()
        {
            return Ok("Aloha! You're authorized!");
        }
    }
}
