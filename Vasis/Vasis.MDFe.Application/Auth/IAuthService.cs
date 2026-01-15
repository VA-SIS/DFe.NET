using Vasis.MDFe.Application.DTOs.Auth;

namespace Vasis.MDFe.Application.Services.Auth;

public interface IAuthService
{
    Task<TokenResponse> LoginAsync(LoginRequest request);
}