using Vasis.MDFe.Core.Enums;

namespace Vasis.MDFe.Application.DTOs.Document;

public class CreateMDFeRequest
{
    public string EmitenteCNPJ { get; set; } = string.Empty;
    public string EmitenteRazaoSocial { get; set; } = string.Empty;
    public string VeiculoPlaca { get; set; } = string.Empty;
    public string CondutorCPF { get; set; } = string.Empty;
    public string CondutorNome { get; set; } = string.Empty;
    public EnvironmentType Environment { get; set; } = EnvironmentType.Homologacao;
}