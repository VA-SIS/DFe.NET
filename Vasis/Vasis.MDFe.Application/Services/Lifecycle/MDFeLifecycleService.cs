using Microsoft.Extensions.Logging;
using Vasis.MDFe.Application.DTOs.Lifecycle;
using Vasis.MDFe.Core.Interfaces.External;

namespace Vasis.MDFe.Application.Services.Lifecycle
{
    public class MDFeLifecycleService
    {
        private readonly IZeusMDFeWrapper _zeusWrapper;
        private readonly ILogger<MDFeLifecycleService> _logger;

        public MDFeLifecycleService(
            IZeusMDFeWrapper zeusWrapper,
            ILogger<MDFeLifecycleService> logger)
        {
            _zeusWrapper = zeusWrapper;
            _logger = logger;
        }

        public async Task<CancelMDFeResponse> CancelMDFeAsync(CancelMDFeRequest request)
        {
            try
            {
                var result = await _zeusWrapper.CancelMDFeAsync(request);

                return new CancelMDFeResponse
                {
                    Success = result.Success,
                    ChaveAcesso = result.ChaveAcesso,
                    Protocolo = result.Protocolo,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cancelar MDFe");
                return new CancelMDFeResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<CloseMDFeResponse> CloseMDFeAsync(CloseMDFeRequest request)
        {
            try
            {
                var result = await _zeusWrapper.CloseMDFeAsync(request);

                return new CloseMDFeResponse
                {
                    Success = result.Success,
                    ChaveAcesso = result.ChaveAcesso,
                    Protocolo = result.Protocolo,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao encerrar MDFe");
                return new CloseMDFeResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}