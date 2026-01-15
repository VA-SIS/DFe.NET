using Microsoft.Extensions.Logging;
using Vasis.MDFe.Application.DTOs.Auth;
using Vasis.MDFe.Core.Interfaces.Services;
using Vasis.MDFe.Core.Entities.Auth;

namespace Vasis.MDFe.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogger<AuthService> _logger;

    // Simulando usuários para o refactor (depois será um repository)
    private static readonly List<User> _users = new()
    {
        new User
        {
            Id = Guid.NewGuid(),
            Username = "admin",
            Email = "admin@vasis.com.br",
            PasswordHash = "AQAAAAEAACcQAAAAEK8+6HvZTqJlmNjmZsKGtQ==", // Hash de "123456"
            IsActive = true,
            Roles = new List<string> { "Admin", "MDFeUser" }
        },
        new User
        {
            Id = Guid.NewGuid(),
            Username = "user",
            Email = "user@vasis.com.br",
            PasswordHash = "AQAAAAEAACcQAAAAEK8+6HvZTqJlmNjmZsKGtQ==", // Hash de "123456"
            IsActive = true,
            Roles = new List<string> { "MDFeUser" }
        }
    };

    public AuthService(
        IJwtTokenService jwtTokenService,
        IPasswordHasher passwordHasher,
        ILogger<AuthService> logger)
    {
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
        _logger = logger;
    }

    public async Task<TokenResponse> LoginAsync(LoginRequest request)
    {
        try
        {
            _logger.LogInformation("Tentativa de login para usuário: {Username}", request.Username);

            await Task.Delay(1); // Simular operação async

            // Buscar usuário
            var user = _users.FirstOrDefault(u =>
                u.Username.Equals(request.Username, StringComparison.OrdinalIgnoreCase) &&
                u.IsActive);

            if (user == null)
            {
                _logger.LogWarning("Usuário não encontrado: {Username}", request.Username);
                throw new UnauthorizedAccessException("Credenciais inválidas");
            }

            // Verificar senha (temporariamente aceitar "123456" para todos)
            if (request.Password != "123456")
            {
                _logger.LogWarning("Senha inválida para usuário: {Username}", request.Username);
                throw new UnauthorizedAccessException("Credenciais inválidas");
            }

            // Gerar token
            var token = _jwtTokenService.GenerateToken(user.Username, user.Roles);

            // Atualizar último login
            user.LastLoginAt = DateTime.UtcNow;

            _logger.LogInformation("Login bem-sucedido para usuário: {Username}", request.Username);

            return new TokenResponse
            {
                Token = token,
                ExpiresIn = 3600, // 1 hora
                TokenType = "Bearer"
            };
        }
        catch (UnauthorizedAccessException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro durante login para usuário: {Username}", request.Username);
            throw new InvalidOperationException("Erro interno durante autenticação");
        }
    }
}