namespace Vasis.MDFe.Core.Interfaces.External
{
    public class ZeusTransmissionResult
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string Protocolo { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}