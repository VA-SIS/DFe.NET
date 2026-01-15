namespace Vasis.MDFe.Core.Interfaces.External;

public interface IZeusWrapper
{
    Task<ZeusCreateResult> CreateMDFeAsync(object mdfeData);
    Task<ZeusValidationResult> ValidateMDFeAsync(string xmlContent);
}

public class ZeusCreateResult
{
    public string ChaveAcesso { get; set; } = string.Empty;
    public string XmlContent { get; set; } = string.Empty;
}

public class ZeusValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
}