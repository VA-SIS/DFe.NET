using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Vasis.MDFe.Application.Services.Auth;
using Vasis.MDFe.Application.DTOs.Auth;
using Vasis.MDFe.Core.Interfaces.Services;

namespace Vasis.MDFe.Tests.Unit.Services;

public class AuthServiceTests
{
    private readonly Mock<IJwtTokenService> _jwtTokenServiceMock;
    private readonly Mock<IPasswordHasher> _passwordHasherMock;
    private readonly Mock<ILogger<AuthService>> _loggerMock;
    private readonly AuthService _authService;

    public AuthServiceTests()
    {
        _jwtTokenServiceMock = new Mock<IJwtTokenService>();
        _passwordHasherMock = new Mock<IPasswordHasher>();
        _loggerMock = new Mock<ILogger<AuthService>>();

        _authService = new AuthService(
            _jwtTokenServiceMock.Object,
            _passwordHasherMock.Object,
            _loggerMock.Object);
    }

    [Fact]
    public async Task Login_WithValidCredentials_ShouldReturnToken()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Username = "admin",
            Password = "123456"
        };

        _jwtTokenServiceMock
            .Setup(x => x.GenerateToken(It.IsAny<string>(), It.IsAny<IEnumerable<string>>()))
            .Returns("fake-jwt-token");

        // Act
        var result = await _authService.LoginAsync(loginRequest);

        // Assert
        result.Should().NotBeNull();
        result.Token.Should().Be("fake-jwt-token");
        result.ExpiresIn.Should().Be(3600);
        result.TokenType.Should().Be("Bearer");

        _jwtTokenServiceMock.Verify(x =>
            x.GenerateToken("admin", It.IsAny<IEnumerable<string>>()), Times.Once);
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

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _authService.LoginAsync(loginRequest));
    }
}