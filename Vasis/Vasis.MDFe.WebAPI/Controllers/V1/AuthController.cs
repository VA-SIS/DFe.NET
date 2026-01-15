using Microsoft.AspNetCore.Mvc;
using Vasis.MDFe.Application.DTOs.Auth;

namespace Vasis.MDFe.WebAPI.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // RED - Implementação mínima para compilar
        throw new NotImplementedException("AuthController não implementado - TDD RED");
    }
}