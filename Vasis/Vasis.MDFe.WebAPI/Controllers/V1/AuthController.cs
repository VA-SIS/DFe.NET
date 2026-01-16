using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Auth;
using Vasis.MDFe.Application.Services.Auth;

namespace Vasis.MDFe.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null)
                return BadRequest("Request inválido");

            var result = await _authService.LoginAsync(request);

            if (result.Success)
                return Ok(result);

            return Unauthorized(result);
        }
    }
}