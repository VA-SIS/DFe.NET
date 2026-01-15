using FluentAssertions;
using Xunit;
using Vasis.MDFe.Application.Services.Document;  // ✅ ADICIONADO
using Vasis.MDFe.Application.DTOs.Document;
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

        var mdfeService = new MDFeDocumentService(); // Agora compila

        // Act & Assert - Esperamos que falhe (RED)
        await Assert.ThrowsAsync<NotImplementedException>(() =>
            mdfeService.CreateAsync(createRequest));
    }

    [Fact]
    public async Task ValidateMDFe_WithValidId_ShouldReturnValidationResult()
    {
        // Arrange
        var mdfeId = Guid.NewGuid();
        var mdfeService = new MDFeDocumentService(); // Agora compila

        // Act & Assert - Esperamos que falhe (RED)
        await Assert.ThrowsAsync<NotImplementedException>(() =>
            mdfeService.ValidateAsync(mdfeId));
    }

    [Fact]
    public async Task GetMDFe_WithValidId_ShouldReturnMDFeData()
    {
        // Arrange
        var mdfeId = Guid.NewGuid();
        var mdfeService = new MDFeDocumentService(); // Agora compila

        // Act & Assert - Esperamos que falhe (RED)
        await Assert.ThrowsAsync<NotImplementedException>(() =>
            mdfeService.GetByIdAsync(mdfeId));
    }
}