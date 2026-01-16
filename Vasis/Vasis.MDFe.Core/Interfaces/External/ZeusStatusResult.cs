namespace Vasis.MDFe.Core.Interfaces.External
{
    public class ZeusStatusResult
    {
        public string ChaveAcesso { get; set; }
        public string Status { get; set; }
        public string Protocolo { get; set; }
        public DateTime? DataHoraProcessamento { get; set; }
        public string Message { get; set; }
    }
}