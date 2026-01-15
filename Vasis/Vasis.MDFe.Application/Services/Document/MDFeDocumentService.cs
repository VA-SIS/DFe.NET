using AutoMapper;
using Microsoft.Extensions.Logging;
using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Core.Entities.Document;
using Vasis.MDFe.Core.Enums;
using Vasis.MDFe.Core.Interfaces.External;
using Vasis.MDFe.Core.Interfaces.Repositories;

namespace Vasis.MDFe.Application.Services.Document;

public class MDFeDocumentService : IMDFeDocumentService
{
    private readonly IMDFeRepository _repository;
    private readonly IZeusWrapper _zeusWrapper;
    private readonly IMapper _mapper;
    private readonly ILogger<MDFeDocumentService> _logger;

    public MDFeDocumentService(
        IMDFeRepository repository,
        IZeusWrapper zeusWrapper,
        IMapper mapper,
        ILogger<MDFeDocumentService> logger)
    {
        _repository = repository;
        _zeusWrapper = zeusWrapper;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<MDFeResponse> CreateAsync(CreateMDFeRequest request)
    {
        try
        {
            _logger.LogInformation("Criando MDFe para emitente: {CNPJ}", request.EmitenteCNPJ);

            // Mapear DTO para entidade
            var document = _mapper.Map<MDFeDocument>(request);
            document.Status = DocumentStatus.Draft;

            // Salvar no repositório
            var savedDocument = await _repository.CreateAsync(document);

            // Mapear entidade para response
            var response = _mapper.Map<MDFeResponse>(savedDocument);

            _logger.LogInformation("MDFe criado com sucesso. ID: {Id}", response.Id);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar MDFe para emitente: {CNPJ}", request.EmitenteCNPJ);
            throw;
        }
    }

    public async Task<MDFeResponse> GetByIdAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Buscando MDFe por ID: {Id}", id);

            var document = await _repository.GetByIdAsync(id);

            if (document == null || document.IsDeleted)
            {
                throw new KeyNotFoundException($"MDFe com ID {id} não encontrado");
            }

            var response = _mapper.Map<MDFeResponse>(document);

            _logger.LogInformation("MDFe encontrado: {Id}", id);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar MDFe por ID: {Id}", id);
            throw;
        }
    }

    public async Task<ValidationResponse> ValidateAsync(Guid id)
    {
        try
        {
            _logger.LogInformation("Validando MDFe: {Id}", id);

            var document = await _repository.GetByIdAsync(id);

            if (document == null || document.IsDeleted)
            {
                throw new KeyNotFoundException($"MDFe com ID {id} não encontrado para validação");
            }

            // Integrar com Zeus para validação
            var zeusResult = await _zeusWrapper.ValidateMDFeAsync(document.XmlContent ?? "");

            var validationResponse = new ValidationResponse
            {
                IsValid = zeusResult.IsValid,
                Errors = zeusResult.Errors,
                Warnings = new List<string>()
            };

            // Atualizar status do documento
            if (zeusResult.IsValid)
            {
                document.Status = DocumentStatus.Validated;
                await _repository.UpdateAsync(document);
            }

            _logger.LogInformation("Validação concluída para MDFe: {Id}. Válido: {IsValid}",
                id, zeusResult.IsValid);

            return validationResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao validar MDFe: {Id}", id);
            throw;
        }
    }
}