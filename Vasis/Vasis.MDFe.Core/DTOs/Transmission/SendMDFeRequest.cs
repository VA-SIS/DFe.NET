namespace Vasis.MDFe.Application.DTOs.Transmission
{
    public class SendMDFeRequest
    {
        public string ChaveAcesso { get; set; }
        public string XmlSigned { get; set; }
        public int TipoAmbiente { get; set; }
        public string UF { get; set; }
    }
}