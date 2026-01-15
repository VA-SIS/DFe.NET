using Vasis.MDFe.Application.DTOs.Auth;

namespace Vasis.MDFe.Application.Services.Auth;

public class AuthService : IAuthService
{
    public async Task<TokenResponse> LoginAsync(LoginRequest request)
    {
        // RED - Implementação mínima para compilar
        throw new NotImplementedException("AuthService não implementado - TDD RED");
    }
}