namespace Vasis.MDFe.Core.Interfaces.Services;

public interface IJwtTokenService
{
    string GenerateToken(string username, IEnumerable<string> roles);
    bool ValidateToken(string token);
    string? GetUsernameFromToken(string token);
}