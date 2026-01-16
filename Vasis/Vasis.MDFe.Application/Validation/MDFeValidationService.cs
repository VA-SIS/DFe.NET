using Microsoft.Extensions.Logging;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Core.Interfaces.External;

namespace Vasis.MDFe.Application.Services.Validation
{
    public class MDFeValidationService
    {
        private readonly IZeusMDFeWrapper _zeusWrapper;
        private readonly ILogger<MDFeValidationService> _logger;

        public MDFeValidationService(
            IZeusMDFeWrapper zeusWrapper,
            ILogger<MDFeValidationService> logger)
        {
            _zeusWrapper = zeusWrapper;
            _logger = logger;
        }

        public async Task<ValidateXmlResponse> ValidateXmlAsync(ValidateXmlRequest request)
        {
            try
            {
                var result = await _zeusWrapper.ValidateXmlAsync(request);

                return new ValidateXmlResponse
                {
                    IsValid = result.IsValid,
                    Errors = result.Errors,
                    Message = result.IsValid ? "XML válido" : "XML inválido"
                };
            }
            catch (Exception ex)
            {
                return CreateValidationErrorResponse(ex);
            }
        }

        public async Task<ValidateBusinessRulesResponse> ValidateBusinessRulesAsync(ValidateBusinessRulesRequest request)
        {
            try
            {
                var result = await _zeusWrapper.ValidateBusinessRulesAsync(request);

                return new ValidateBusinessRulesResponse
                {
                    IsValid = result.IsValid,
                    Errors = result.Errors,
                    Warnings = result.Warnings,
                    Message = result.IsValid ? "Regras de negócio válidas" : "Regras de negócio inválidas"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao validar regras de negócio");
                return new ValidateBusinessRulesResponse
                {
                    IsValid = false,
                    Errors = new List<string> { ex.Message },
                    Message = "Erro na validação"
                };
            }
        }

        private ValidateXmlResponse CreateValidationErrorResponse(Exception ex)
        {
            _logger.LogError(ex, "Erro ao validar XML");
            return new ValidateXmlResponse
            {
                IsValid = false,
                Errors = new List<string> { ex.Message },
                Message = "Erro na validação"
            };
        }
    }
}