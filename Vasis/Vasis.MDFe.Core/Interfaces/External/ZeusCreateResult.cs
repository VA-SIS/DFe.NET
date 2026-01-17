namespace Vasis.MDFe.Core.Interfaces.External
{
    public class ZeusCreateResult
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string XmlGerado { get; set; }
        public string ErrorMessage { get; set; }
    }
}