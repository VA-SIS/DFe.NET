using Microsoft.Extensions.Logging;
using Vasis.MDFe.Application.DTOs.Transmission;
using Vasis.MDFe.Core.Interfaces.External;

namespace Vasis.MDFe.Application.Services.Transmission
{
    public class MDFeTransmissionService
    {
        private readonly IZeusMDFeWrapper _zeusWrapper;
        private readonly ILogger<MDFeTransmissionService> _logger;

        public MDFeTransmissionService(
            IZeusMDFeWrapper zeusWrapper,
            ILogger<MDFeTransmissionService> logger)
        {
            _zeusWrapper = zeusWrapper;
            _logger = logger;
        }

        public async Task<SendMDFeResponse> SendMDFeAsync(SendMDFeRequest request)
        {
            try
            {
                var result = await _zeusWrapper.SendMDFeAsync(request);

                return new SendMDFeResponse
                {
                    Success = result.Success,
                    ChaveAcesso = result.ChaveAcesso,
                    Protocolo = result.Protocolo,
                    Status = result.Status,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao enviar MDFe");
                return new SendMDFeResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<CheckStatusResponse> CheckStatusAsync(CheckStatusRequest request)
        {
            try
            {
                var result = await _zeusWrapper.CheckStatusAsync(request);

                return new CheckStatusResponse
                {
                    ChaveAcesso = result.ChaveAcesso,
                    Status = result.Status,
                    Protocolo = result.Protocolo,
                    DataHoraProcessamento = result.DataHoraProcessamento,
                    Message = result.Message
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar status");
                return new CheckStatusResponse
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<ServiceStatusResponse> GetServiceStatusAsync()
        {
            try
            {
                var result = await _zeusWrapper.GetServiceStatusAsync();

                return new ServiceStatusResponse
                {
                    Status = result.Status,
                    Message = result.Message,
                    DataHoraConsulta = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar status do serviço");
                return new ServiceStatusResponse
                {
                    Status = "Erro",
                    Message = ex.Message,
                    DataHoraConsulta = DateTime.UtcNow
                };
            }
        }
    }
}