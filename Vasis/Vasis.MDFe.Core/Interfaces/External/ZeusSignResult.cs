namespace Vasis.MDFe.Core.Interfaces.External
{
    public class ZeusSignResult
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string XmlSigned { get; set; }
        public string ErrorMessage { get; set; }
    }
}