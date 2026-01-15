using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Net;
using Xunit;
using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Core.Enums;

namespace Vasis.MDFe.Tests.Integration.Controllers;

public class MDFeControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public MDFeControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task POST_CreateMDFe_WithValidData_ShouldReturnCreated()
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

        // Act
        var response = await _client.PostAsJsonAsync("/api/v1/mdfe", createRequest);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var mdfeResponse = await response.Content.ReadFromJsonAsync<MDFeResponse>();
        mdfeResponse.Should().NotBeNull();
        mdfeResponse!.Status.Should().Be(DocumentStatus.Draft);
    }
}