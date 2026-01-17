using Vasis.MDFe.Core.Entities.Document;

namespace Vasis.MDFe.Core.Interfaces.Repositories
{
    public interface IMDFeRepository
    {
        Task<MDFeDocument> GetByIdAsync(int id);
        Task<MDFeDocument> GetByChaveAcessoAsync(string chaveAcesso);
        Task<IEnumerable<MDFeDocument>> GetAllAsync();
        Task AddAsync(MDFeDocument document);
        Task UpdateAsync(MDFeDocument document);
        Task DeleteAsync(MDFeDocument document);
    }
}