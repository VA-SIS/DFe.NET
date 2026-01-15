using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;

namespace Vasis.MDFe.Application.Services.Document;

public interface IMDFeDocumentService
{
    Task<MDFeResponse> CreateAsync(CreateMDFeRequest request);
    Task<MDFeResponse> GetByIdAsync(Guid id);
    Task<ValidationResponse> ValidateAsync(Guid id);
}