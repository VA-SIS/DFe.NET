using AutoMapper;
using Microsoft.Extensions.Logging;
using Vasis.MDFe.Application.DTOs.Generation;
using Vasis.MDFe.Core.Interfaces.External;
using Vasis.MDFe.Core.Interfaces.Repositories;

namespace Vasis.MDFe.Application.Services.Generation
{
    public class MDFeGenerationService
    {
        private readonly IMDFeRepository _repository;
        private readonly IZeusMDFeWrapper _zeusWrapper;
        private readonly IMapper _mapper;
        private readonly ILogger<MDFeGenerationService> _logger;

        public MDFeGenerationService(
            IMDFeRepository repository,
            IZeusMDFeWrapper zeusWrapper,
            IMapper mapper,
            ILogger<MDFeGenerationService> logger)
        {
            _repository = repository;
            _zeusWrapper = zeusWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateMDFeResponse> CreateMDFeAsync(CreateMDFeRequest request)
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

        public async Task<SignMDFeResponse> SignMDFeAsync(SignMDFeRequest request)
        {
            try
            {
                var zeusResult = await _zeusWrapper.SignMDFeAsync(request);

                if (zeusResult.Success)
                {
                    return new SignMDFeResponse
                    {
                        Success = true,
                        ChaveAcesso = zeusResult.ChaveAcesso,
                        XmlSigned = zeusResult.XmlSigned,
                        Message = "MDFe assinado com sucesso"
                    };
                }

                return new SignMDFeResponse
                {
                    Success = false,
                    Message = zeusResult.ErrorMessage
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao assinar MDFe");
                return new SignMDFeResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        private async Task<CreateMDFeResponse> ProcessSuccessfulCreation(CreateMDFeRequest request, ZeusCreateResult zeusResult)
        {
            return new CreateMDFeResponse
            {
                Success = true,
                ChaveAcesso = zeusResult.ChaveAcesso,
                XmlContent = zeusResult.XmlGerado,
                Message = "MDFe criado com sucesso"
            };
        }

        private CreateMDFeResponse CreateFailureResponse(string errorMessage)
        {
            return new CreateMDFeResponse
            {
                Success = false,
                Message = errorMessage
            };
        }

        private CreateMDFeResponse HandleException(Exception ex, string context)
        {
            _logger.LogError(ex, context);
            return new CreateMDFeResponse
            {
                Success = false,
                Message = ex.Message
            };
        }
    }
}