namespace Vasis.MDFe.Application.DTOs.Lifecycle
{
    public class CancelMDFeRequest
    {
        public string ChaveAcesso { get; set; }
        public string Protocolo { get; set; }
        public string Justificativa { get; set; }
        public int TipoAmbiente { get; set; }
        public string UF { get; set; }
    }
}