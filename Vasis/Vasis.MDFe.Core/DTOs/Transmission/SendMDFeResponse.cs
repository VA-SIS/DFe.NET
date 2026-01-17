namespace Vasis.MDFe.Application.DTOs.Transmission
{
    public class SendMDFeResponse
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string Protocolo { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}