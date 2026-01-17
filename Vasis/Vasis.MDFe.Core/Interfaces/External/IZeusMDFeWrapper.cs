using Vasis.MDFe.Application.DTOs.Generation;
using Vasis.MDFe.Application.DTOs.Transmission;
using Vasis.MDFe.Application.DTOs.Validation;
using Vasis.MDFe.Application.DTOs.Query;
using Vasis.MDFe.Application.DTOs.Lifecycle;

namespace Vasis.MDFe.Core.Interfaces.External
{
    public interface IZeusMDFeWrapper
    {
        Task<ZeusCreateResult> CreateMDFeAsync(CreateMDFeRequest request);
        Task<ZeusSignResult> SignMDFeAsync(SignMDFeRequest request);
        Task<ZeusValidationResult> ValidateXmlAsync(ValidateXmlRequest request);
        Task<ZeusValidationResult> ValidateBusinessRulesAsync(ValidateBusinessRulesRequest request);
        Task<ZeusTransmissionResult> SendMDFeAsync(SendMDFeRequest request);
        Task<ZeusStatusResult> CheckStatusAsync(CheckStatusRequest request);
        Task<ZeusServiceStatusResult> GetServiceStatusAsync();
        Task<ZeusQueryResult> ConsultMDFeAsync(ConsultMDFeRequest request);
        Task<ZeusCancelResult> CancelMDFeAsync(CancelMDFeRequest request);
        Task<ZeusCloseResult> CloseMDFeAsync(CloseMDFeRequest request);
    }
}