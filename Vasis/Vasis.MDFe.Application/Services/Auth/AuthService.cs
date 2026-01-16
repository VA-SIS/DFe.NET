using Vasis.MDFe.Application.DTOs.Auth;
using Vasis.MDFe.Core.Interfaces.Services;

namespace Vasis.MDFe.Application.Services.Auth
{
    public class AuthService
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IJwtTokenService jwtTokenService, IPasswordHasher passwordHasher)
        {
            _jwtTokenService = jwtTokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            if (IsValidCredentials(request.Username, request.Password))
            {
                return await CreateSuccessResponse(request.Username);
            }

            return CreateFailureResponse();
        }

        private bool IsValidCredentials(string username, string password)
        {
            return username == "admin" && password == "123456";
        }

        private async Task<LoginResponse> CreateSuccessResponse(string username)
        {
            var token = _jwtTokenService.GenerateToken(username);

            return new LoginResponse
            {
                Success = true,
                Token = token,
                Username = username,
                ExpiresAt = DateTime.UtcNow.AddHours(24)
            };
        }

        private LoginResponse CreateFailureResponse()
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Credenciais inválidas"
            };
        }
    }
}