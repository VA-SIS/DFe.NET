using FluentAssertions;
using Xunit;
using Vasis.MDFe.Application.Services.Document;
using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Core.Enums;

namespace Vasis.MDFe.Tests.Unit.Services;

public class MDFeDocumentServiceTests
{
    [Fact]
    public async Task CreateMDFe_WithValidData_ShouldReturnMDFeResponse()
    {
        // Arrange
        var createRequest = new CreateMDFeRequest
        {
            EmitenteCNPJ = "12345678000195",
            EmitenteRazaoSocial = "Empresa Teste LTDA",
            VeiculoPlaca = "ABC1234",
            CondutorCPF = "12345678901",
            CondutorNome = "João Silva",
            Environment = EnvironmentType.Homologacao
        };

        var mdfeService = new MDFeDocumentService();

        // Act
        var result = await mdfeService.CreateAsync(createRequest);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().NotBe(Guid.Empty);
        result.Status.Should().Be(DocumentStatus.Draft);
        result.ChaveAcesso.Should().NotBeNullOrEmpty();
        result.EmitenteCNPJ.Should().Be("12345678000195");
        result.EmitenteRazaoSocial.Should().Be("Empresa Teste LTDA");
    }

    [Fact]
    public async Task ValidateMDFe_WithValidId_ShouldReturnValidationResult()
    {
        // Arrange
        var mdfeService = new MDFeDocumentService();

        // Primeiro criar um MDFe
        var createRequest = new CreateMDFeRequest
        {
            EmitenteCNPJ = "12345678000195",
            EmitenteRazaoSocial = "Empresa Teste LTDA"
        };
        var createdMDFe = await mdfeService.CreateAsync(createRequest);

        // Act
        var result = await mdfeService.ValidateAsync(createdMDFe.Id);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task GetMDFe_WithValidId_ShouldReturnMDFeData()
    {
        // Arrange
        var mdfeService = new MDFeDocumentService();

        // Primeiro criar um MDFe
        var createRequest = new CreateMDFeRequest
        {
            EmitenteCNPJ = "12345678000195",
            EmitenteRazaoSocial = "Empresa Teste LTDA"
        };
        var createdMDFe = await mdfeService.CreateAsync(createRequest);

        // Act
        var result = await mdfeService.GetByIdAsync(createdMDFe.Id);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(createdMDFe.Id);
        result.EmitenteCNPJ.Should().Be("12345678000195");
    }

    [Fact]
    public async Task GetMDFe_WithInvalidId_ShouldThrowException()
    {
        // Arrange
        var mdfeService = new MDFeDocumentService();
        var invalidId = Guid.NewGuid();

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            mdfeService.GetByIdAsync(invalidId));
    }
}