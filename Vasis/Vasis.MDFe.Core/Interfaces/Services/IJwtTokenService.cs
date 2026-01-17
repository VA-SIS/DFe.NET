namespace Vasis.MDFe.Core.Interfaces.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(string username);
    }
}