using Vasis.MDFe.Application.DTOs.Document;
using Vasis.MDFe.Application.DTOs.Validation;

namespace Vasis.MDFe.Application.Services.Document;

public class MDFeDocumentService : IMDFeDocumentService
{
    public async Task<MDFeResponse> CreateAsync(CreateMDFeRequest request)
    {
        throw new NotImplementedException(); // RED - Para TDD
    }

    public async Task<MDFeResponse> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException(); // RED - Para TDD
    }

    public async Task<ValidationResponse> ValidateAsync(Guid id)
    {
        throw new NotImplementedException(); // RED - Para TDD
    }
}