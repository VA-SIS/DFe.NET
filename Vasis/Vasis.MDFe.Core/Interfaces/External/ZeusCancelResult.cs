namespace Vasis.MDFe.Core.Interfaces.External
{
    public class ZeusCancelResult
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string Protocolo { get; set; }
        public string Message { get; set; }
    }
}