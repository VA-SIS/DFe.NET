using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Core.Enums;

namespace Vasis.MDFe.Application.Services.Document;

public class MDFeDocumentService : IMDFeDocumentService
{
    // Simulando um "banco de dados" em memória para os testes
    private static readonly Dictionary<Guid, MDFeResponse> _documents = new();

    public async Task<MDFeResponse> CreateAsync(CreateMDFeRequest request)
    {
        await Task.Delay(1); // Para ser async

        // GREEN - Implementação mínima para passar no teste
        var response = new MDFeResponse
        {
            Id = Guid.NewGuid(),
            ChaveAcesso = GenerateChaveAcesso(),
            Status = DocumentStatus.Draft,
            EmitenteCNPJ = request.EmitenteCNPJ,
            EmitenteRazaoSocial = request.EmitenteRazaoSocial,
            CreatedAt = DateTime.UtcNow
        };

        _documents[response.Id] = response;
        return response;
    }

    public async Task<MDFeResponse> GetByIdAsync(Guid id)
    {
        await Task.Delay(1); // Para ser async

        // GREEN - Implementação mínima para passar no teste
        if (_documents.TryGetValue(id, out var document))
        {
            return document;
        }

        throw new KeyNotFoundException($"MDFe com ID {id} não encontrado");
    }

    public async Task<ValidationResponse> ValidateAsync(Guid id)
    {
        await Task.Delay(1); // Para ser async

        // GREEN - Implementação mínima para passar no teste
        if (_documents.ContainsKey(id))
        {
            return new ValidationResponse
            {
                IsValid = true,
                Errors = new List<string>(),
                Warnings = new List<string>()
            };
        }

        throw new KeyNotFoundException($"MDFe com ID {id} não encontrado para validação");
    }

    private static string GenerateChaveAcesso()
    {
        // GREEN - Gerar chave fake para os testes
        return DateTime.Now.ToString("yyyyMMddHHmmss") + Random.Shared.Next(1000, 9999);
    }
}