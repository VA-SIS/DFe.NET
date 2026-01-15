using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using AutoMapper;
using Vasis.MDFe.Application.Services.Document;
using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Core.Enums;
using Vasis.MDFe.Core.Interfaces.Repositories;
using Vasis.MDFe.Core.Interfaces.External;
using Vasis.MDFe.Core.Entities.Document;

namespace Vasis.MDFe.Tests.Unit.Services;

public class MDFeDocumentServiceTests
{
    private readonly Mock<IMDFeRepository> _repositoryMock;
    private readonly Mock<IZeusWrapper> _zeusWrapperMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ILogger<MDFeDocumentService>> _loggerMock;
    private readonly MDFeDocumentService _mdfeService;

    public MDFeDocumentServiceTests()
    {
        _repositoryMock = new Mock<IMDFeRepository>();
        _zeusWrapperMock = new Mock<IZeusWrapper>();
        _mapperMock = new Mock<IMapper>();
        _loggerMock = new Mock<ILogger<MDFeDocumentService>>();

        _mdfeService = new MDFeDocumentService(
            _repositoryMock.Object,
            _zeusWrapperMock.Object,
            _mapperMock.Object,
            _loggerMock.Object);
    }

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

        var document = new MDFeDocument
        {
            Id = Guid.NewGuid(),
            EmitenteCNPJ = createRequest.EmitenteCNPJ,
            EmitenteRazaoSocial = createRequest.EmitenteRazaoSocial,
            Status = DocumentStatus.Draft
        };

        var response = new MDFeResponse
        {
            Id = document.Id,
            EmitenteCNPJ = document.EmitenteCNPJ,
            EmitenteRazaoSocial = document.EmitenteRazaoSocial,
            Status = DocumentStatus.Draft,
            ChaveAcesso = "fake-chave-acesso"
        };

        _mapperMock.Setup(x => x.Map<MDFeDocument>(createRequest)).Returns(document);
        _repositoryMock.Setup(x => x.CreateAsync(It.IsAny<MDFeDocument>())).ReturnsAsync(document);
        _mapperMock.Setup(x => x.Map<MDFeResponse>(document)).Returns(response);

        // Act
        var result = await _mdfeService.CreateAsync(createRequest);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().NotBe(Guid.Empty);
        result.Status.Should().Be(DocumentStatus.Draft);
        result.EmitenteCNPJ.Should().Be("12345678000195");
        result.EmitenteRazaoSocial.Should().Be("Empresa Teste LTDA");

        _repositoryMock.Verify(x => x.CreateAsync(It.IsAny<MDFeDocument>()), Times.Once);
    }

    [Fact]
    public async Task ValidateMDFe_WithValidId_ShouldReturnValidationResult()
    {
        // Arrange
        var documentId = Guid.NewGuid();
        var document = new MDFeDocument
        {
            Id = documentId,
            EmitenteCNPJ = "12345678000195",
            EmitenteRazaoSocial = "Empresa Teste LTDA",
            XmlContent = "<MDFe></MDFe>",
            Status = DocumentStatus.Draft
        };

        var zeusResult = new ZeusValidationResult
        {
            IsValid = true,
            Errors = new List<string>()
        };

        _repositoryMock.Setup(x => x.GetByIdAsync(documentId)).ReturnsAsync(document);
        _zeusWrapperMock.Setup(x => x.ValidateMDFeAsync(It.IsAny<string>())).ReturnsAsync(zeusResult);
        _repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<MDFeDocument>())).ReturnsAsync(document);

        // Act
        var result = await _mdfeService.ValidateAsync(documentId);

        // Assert
        result.Should().NotBeNull();
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();

        _zeusWrapperMock.Verify(x => x.ValidateMDFeAsync(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task GetMDFe_WithValidId_ShouldReturnMDFeData()
    {
        // Arrange
        var documentId = Guid.NewGuid();
        var document = new MDFeDocument
        {
            Id = documentId,
            EmitenteCNPJ = "12345678000195",
            EmitenteRazaoSocial = "Empresa Teste LTDA"
        };

        var response = new MDFeResponse
        {
            Id = documentId,
            EmitenteCNPJ = "12345678000195",
            EmitenteRazaoSocial = "Empresa Teste LTDA"
        };

        _repositoryMock.Setup(x => x.GetByIdAsync(documentId)).ReturnsAsync(document);
        _mapperMock.Setup(x => x.Map<MDFeResponse>(document)).Returns(response);

        // Act
        var result = await _mdfeService.GetByIdAsync(documentId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(documentId);
        result.EmitenteCNPJ.Should().Be("12345678000195");

        _repositoryMock.Verify(x => x.GetByIdAsync(documentId), Times.Once);
    }

    [Fact]
    public async Task GetMDFe_WithInvalidId_ShouldThrowException()
    {
        // Arrange
        var invalidId = Guid.NewGuid();
        _repositoryMock.Setup(x => x.GetByIdAsync(invalidId)).ReturnsAsync((MDFeDocument?)null);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            _mdfeService.GetByIdAsync(invalidId));
    }
}