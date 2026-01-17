namespace Vasis.MDFe.Application.DTOs.Transmission
{
    public class CheckStatusResponse
    {
        public string ChaveAcesso { get; set; }
        public string Status { get; set; }
        public string Protocolo { get; set; }
        public DateTime? DataHoraProcessamento { get; set; }
        public string Message { get; set; }
        public DateTime ConsultedAt { get; set; } = DateTime.UtcNow;
    }
}