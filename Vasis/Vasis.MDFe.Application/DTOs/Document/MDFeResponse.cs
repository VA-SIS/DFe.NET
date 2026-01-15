using Vasis.MDFe.Core.Enums;

namespace Vasis.MDFe.Application.DTOs.Document;

public class MDFeResponse
{
    public Guid Id { get; set; }
    public string ChaveAcesso { get; set; } = string.Empty;
    public DocumentStatus Status { get; set; }  // Renomeado para evitar conflito
    public string EmitenteCNPJ { get; set; } = string.Empty;
    public string EmitenteRazaoSocial { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}