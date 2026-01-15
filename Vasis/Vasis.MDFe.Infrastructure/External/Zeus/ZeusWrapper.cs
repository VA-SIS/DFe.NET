namespace Vasis.MDFe.Infrastructure.External.Zeus;

public class ZeusWrapper : IZeusWrapper
{
    public async Task<ZeusCreateResult> CreateMDFeAsync(object mdfeData)
    {
        // RED - Implementação mínima para compilar
        throw new NotImplementedException("ZeusWrapper não implementado - TDD RED");
    }

    public async Task<ZeusValidationResult> ValidateMDFeAsync(string xmlContent)
    {
        // RED - Implementação mínima para compilar
        throw new NotImplementedException("ZeusWrapper não implementado - TDD RED");
    }
}