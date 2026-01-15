using FluentAssertions;
using Xunit;
using Vasis.MDFe.Infrastructure.External.Zeus;  // ✅ ADICIONADO
using Vasis.MDFe.Core.Enums;

namespace Vasis.MDFe.Tests.Integration.Zeus;

public class ZeusIntegrationTests
{
    [Fact]
    public async Task ZeusWrapper_CreateMDFe_ShouldIntegrateWithZeusLibrary()
    {
        // Arrange
        var zeusWrapper = new ZeusWrapper(); // Agora compila

        var mdfeData = new
        {
            EmitenteCNPJ = "12345678000195",
            EmitenteRazaoSocial = "Empresa Teste",
            VeiculoPlaca = "ABC1234",
            Environment = EnvironmentType.Homologacao
        };

        // Act & Assert - Esperamos que falhe (RED)
        await Assert.ThrowsAsync<NotImplementedException>(() =>
            zeusWrapper.CreateMDFeAsync(mdfeData));
    }

    [Fact]
    public async Task ZeusWrapper_ValidateMDFe_ShouldValidateWithZeus()
    {
        // Arrange
        var zeusWrapper = new ZeusWrapper(); // Agora compila
        var xmlContent = "<xml>sample mdfe xml</xml>";

        // Act & Assert - Esperamos que falhe (RED)
        await Assert.ThrowsAsync<NotImplementedException>(() =>
            zeusWrapper.ValidateMDFeAsync(xmlContent));
    }
}