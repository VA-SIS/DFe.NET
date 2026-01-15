using Vasis.MDFe.Core.Entities.Document;

namespace Vasis.MDFe.Core.Interfaces.Repositories;

public interface IMDFeRepository
{
    Task<MDFeDocument> CreateAsync(MDFeDocument document);
    Task<MDFeDocument?> GetByIdAsync(Guid id);
    Task<MDFeDocument> UpdateAsync(MDFeDocument document);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<MDFeDocument>> GetByEmitenteCNPJAsync(string cnpj);
}