namespace Vasis.MDFe.Application.DTOs.Transmission
{
    public class CheckStatusRequest
    {
        public string ChaveAcesso { get; set; }
        public int TipoAmbiente { get; set; }
        public string UF { get; set; }
    }
}