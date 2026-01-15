using FluentAssertions;
using Xunit;
using Vasis.MDFe.Infrastructure.External.Zeus;
using Vasis.MDFe.Core.Enums;

namespace Vasis.MDFe.Tests.Integration.Zeus;

public class ZeusIntegrationTests
{
    [Fact]
    public async Task ZeusWrapper_CreateMDFe_ShouldIntegrateWithZeusLibrary()
    {
        // Arrange
        var zeusWrapper = new ZeusWrapper();

        var mdfeData = new
        {
            EmitenteCNPJ = "12345678000195",
            EmitenteRazaoSocial = "Empresa Teste",
            VeiculoPlaca = "ABC1234",
            Environment = EnvironmentType.Homologacao
        };

        // Act
        var result = await zeusWrapper.CreateMDFeAsync(mdfeData);

        // Assert
        result.Should().NotBeNull();
        result.ChaveAcesso.Should().NotBeNullOrEmpty();
        result.ChaveAcesso.Should().HaveLength(44); // Chave de acesso tem 44 dígitos
        result.XmlContent.Should().NotBeNullOrEmpty();
        result.XmlContent.Should().Contain("<MDFe>");
    }

    [Fact]
    public async Task ZeusWrapper_ValidateMDFe_ShouldValidateWithZeus()
    {
        // Arrange
        var zeusWrapper = new ZeusWrapper();
        var xmlContent = "<MDFe><infMDFe><ide><cUF>35</cUF></ide></infMDFe></MDFe>";

        // Act
        var result = await zeusWrapper.ValidateMDFeAsync(xmlContent);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task ZeusWrapper_ValidateMDFe_WithEmptyXml_ShouldReturnInvalid()
    {
        // Arrange
        var zeusWrapper = new ZeusWrapper();
        var xmlContent = "";

        // Act
        var result = await zeusWrapper.ValidateMDFeAsync(xmlContent);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeFalse();
    }
}