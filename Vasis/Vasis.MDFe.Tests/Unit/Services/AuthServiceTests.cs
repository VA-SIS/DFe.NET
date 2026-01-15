using FluentAssertions;
using Xunit;
using Vasis.MDFe.Application.Services.Auth;
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

        var authService = new AuthService();

        // Act
        var result = await authService.LoginAsync(loginRequest);

        // Assert
        result.Should().NotBeNull();
        result.Token.Should().NotBeNullOrEmpty();
        result.ExpiresIn.Should().BeGreaterThan(0);
        result.TokenType.Should().Be("Bearer");
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

        var authService = new AuthService();

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            authService.LoginAsync(loginRequest));
    }
}