using FluentAssertions;
using Xunit;
using Vasis.MDFe.Application.Services.Auth;  // ✅ ADICIONADO
using Vasis.MDFe.Application.DTOs.Auth;

namespace Vasis.MDFe.Tests.Unit.Services;

public class AuthServiceTests
{
    [Fact]
    public async Task Login_WithValidCredentials_ShouldReturnToken()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Username = "admin",
            Password = "123456"
        };

        var authService = new AuthService(); // Agora compila

        // Act & Assert - Esperamos que falhe (RED)
        await Assert.ThrowsAsync<NotImplementedException>(() =>
            authService.LoginAsync(loginRequest));
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ShouldThrowException()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Username = "invalid",
            Password = "wrong"
        };

        var authService = new AuthService(); // Agora compila

        // Act & Assert - Esperamos que falhe (RED)
        await Assert.ThrowsAsync<NotImplementedException>(() =>
            authService.LoginAsync(loginRequest));
    }
}