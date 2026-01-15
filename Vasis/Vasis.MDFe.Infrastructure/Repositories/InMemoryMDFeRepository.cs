using Vasis.MDFe.Core.Entities.Document;
using Vasis.MDFe.Core.Interfaces.Repositories;

namespace Vasis.MDFe.Infrastructure.Repositories;

public class InMemoryMDFeRepository : IMDFeRepository
{
    private static readonly Dictionary<Guid, MDFeDocument> _documents = new();

    public async Task<MDFeDocument> CreateAsync(MDFeDocument document)
    {
        await Task.Delay(1);

        document.CreatedAt = DateTime.UtcNow;
        _documents[document.Id] = document;

        return document;
    }

    public async Task<MDFeDocument?> GetByIdAsync(Guid id)
    {
        await Task.Delay(1);

        _documents.TryGetValue(id, out var document);
        return document;
    }

    public async Task<MDFeDocument> UpdateAsync(MDFeDocument document)
    {
        await Task.Delay(1);

        if (!_documents.ContainsKey(document.Id))
            throw new KeyNotFoundException($"MDFe com ID {document.Id} não encontrado");

        document.UpdatedAt = DateTime.UtcNow;
        _documents[document.Id] = document;

        return document;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await Task.Delay(1);

        if (_documents.TryGetValue(id, out var document))
        {
            document.IsDeleted = true;
            document.UpdatedAt = DateTime.UtcNow;
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<MDFeDocument>> GetByEmitenteCNPJAsync(string cnpj)
    {
        await Task.Delay(1);

        return _documents.Values
            .Where(d => !d.IsDeleted && d.EmitenteCNPJ == cnpj)
            .ToList();
    }
}