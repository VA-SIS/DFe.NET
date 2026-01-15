using Vasis.MDFe.Core.Entities.Common;
using Vasis.MDFe.Core.Enums;

namespace Vasis.MDFe.Core.Entities.Document;

public class MDFeDocument : BaseEntity
{
    public string ChaveAcesso { get; set; } = string.Empty;
    public string NumeroMDFe { get; set; } = string.Empty;
    public string SerieMDFe { get; set; } = string.Empty;
    public DocumentStatus Status { get; set; } = DocumentStatus.Draft;
    public EnvironmentType Environment { get; set; } = EnvironmentType.Homologacao;

    // Dados do Emitente
    public string EmitenteCNPJ { get; set; } = string.Empty;
    public string EmitenteRazaoSocial { get; set; } = string.Empty;
    public string EmitenteUF { get; set; } = string.Empty;

    // Dados do Transporte
    public string VeiculoPlaca { get; set; } = string.Empty;
    public string VeiculoUF { get; set; } = string.Empty;
    public string CondutorCPF { get; set; } = string.Empty;
    public string CondutorNome { get; set; } = string.Empty;

    // Dados Fiscais
    public decimal ValorTotalCarga { get; set; }
    public string UnidadeMedida { get; set; } = string.Empty;
    public decimal QuantidadeCarga { get; set; }

    // XML e Validação
    public string? XmlContent { get; set; }
    public string? ValidationErrors { get; set; }
    public string? ProtocoloAutorizacao { get; set; }
    public DateTime? DataAutorizacao { get; set; }

    // Relacionamentos
    public virtual ICollection<MDFeDocumentItem> Itens { get; set; } = new List<MDFeDocumentItem>();
}