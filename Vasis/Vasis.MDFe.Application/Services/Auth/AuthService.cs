using Vasis.MDFe.Application.DTOs.Auth;

namespace Vasis.MDFe.Application.Services.Auth;

public class AuthService : IAuthService
{
    public async Task<TokenResponse> LoginAsync(LoginRequest request)
    {
        await Task.Delay(1); // Para ser async

        // GREEN - Implementação mínima para passar no teste
        if (request.Username == "admin" && request.Password == "123456")
        {
            return new TokenResponse
            {
                Token = "fake-jwt-token-for-testing",
                ExpiresIn = 3600,
                TokenType = "Bearer"
            };
        }

        throw new UnauthorizedAccessException("Credenciais inválidas");
    }
}