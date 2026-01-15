using Vasis.MDFe.Core.Entities.Common;

namespace Vasis.MDFe.Core.Entities.Document;

public class MDFeDocumentItem : BaseEntity
{
    public Guid MDFeDocumentId { get; set; }
    public string CodigoProduto { get; set; } = string.Empty;
    public string DescricaoProduto { get; set; } = string.Empty;
    public decimal Quantidade { get; set; }
    public string UnidadeMedida { get; set; } = string.Empty;
    public decimal Valor { get; set; }

    // Relacionamento
    public virtual MDFeDocument? MDFeDocument { get; set; }
}