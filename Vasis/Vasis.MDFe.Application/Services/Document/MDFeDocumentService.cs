using AutoMapper;
using Microsoft.Extensions.Logging;
using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Core.Entities.Document;
using Vasis.MDFe.Core.Interfaces.External;
using Vasis.MDFe.Core.Interfaces.Repositories;

namespace Vasis.MDFe.Application.Services.Document
{
    public class MDFeDocumentService
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

        public async Task<MDFeResponse> CreateMDFeAsync(CreateMDFeRequest request)
        {
            try
            {
                var zeusResult = await _zeusWrapper.CreateMDFeAsync(request);

                if (zeusResult.Success)
                {
                    return await ProcessSuccessfulCreation(request, zeusResult);
                }

                return CreateFailureResponse(zeusResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "Erro ao criar MDFe");
            }
        }

        public async Task<ValidationResponse> ValidateMDFeAsync(CreateMDFeRequest request)
        {
            try
            {
                var result = await _zeusWrapper.ValidateMDFeAsync(request);

                return new ValidationResponse
                {
                    IsValid = result.IsValid,
                    Errors = result.Errors,
                    Message = result.IsValid ? "MDFe válido" : "MDFe inválido"
                };
            }
            catch (Exception ex)
            {
                return CreateValidationErrorResponse(ex);
            }
        }

        public async Task<MDFeResponse> GetMDFeAsync(int id)
        {
            var document = await _repository.GetByIdAsync(id);
            return _mapper.Map<MDFeResponse>(document);
        }

        public async Task<IEnumerable<MDFeResponse>> GetAllMDFeAsync()
        {
            var documents = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MDFeResponse>>(documents);
        }

        public async Task<bool> DeleteMDFeAsync(int id)
        {
            var document = await _repository.GetByIdAsync(id);
            if (document == null)
                return false;

            await _repository.DeleteAsync(document);
            return true;
        }

        private async Task<MDFeResponse> ProcessSuccessfulCreation(CreateMDFeRequest request, ZeusCreateResult zeusResult)
        {
            var document = _mapper.Map<MDFeDocument>(request);
            document.ChaveAcesso = zeusResult.ChaveAcesso;
            document.XmlContent = zeusResult.XmlGerado;

            await _repository.AddAsync(document);

            return new MDFeResponse
            {
                Success = true,
                ChaveAcesso = zeusResult.ChaveAcesso,
                XmlContent = zeusResult.XmlGerado,
                Message = "MDFe criado com sucesso"
            };
        }

        private MDFeResponse CreateFailureResponse(string errorMessage)
        {
            return new MDFeResponse
            {
                Success = false,
                Message = errorMessage
            };
        }

        private MDFeResponse HandleException(Exception ex, string context)
        {
            _logger.LogError(ex, context);
            return new MDFeResponse
            {
                Success = false,
                Message = ex.Message
            };
        }

        private ValidationResponse CreateValidationErrorResponse(Exception ex)
        {
            _logger.LogError(ex, "Erro ao validar MDFe");
            return new ValidationResponse
            {
                IsValid = false,
                Errors = new List<string> { ex.Message },
                Message = "Erro na validação"
            };
        }
    }
}