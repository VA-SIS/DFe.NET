namespace Vasis.MDFe.Application.DTOs.Lifecycle
{
    public class CloseMDFeRequest
    {
        public string ChaveAcesso { get; set; }
        public string Protocolo { get; set; }
        public DateTime DataHoraEncerramento { get; set; }
        public string CodigoMunicipioEncerramento { get; set; }
        public int TipoAmbiente { get; set; }
        public string UF { get; set; }
    }
}