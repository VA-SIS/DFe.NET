namespace Vasis.MDFe.Application.DTOs.Lifecycle
{
    public class CancelMDFeResponse
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string Protocolo { get; set; }
        public string Message { get; set; }
        public DateTime CancelledAt { get; set; } = DateTime.UtcNow;
    }
}