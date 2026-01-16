namespace Vasis.MDFe.Application.DTOs.Query
{
    public class ConsultMDFeResponse
    {
        public string ChaveAcesso { get; set; }
        public string Status { get; set; }
        public string XmlRetorno { get; set; }
        public string Message { get; set; }
        public DateTime ConsultedAt { get; set; } = DateTime.UtcNow;
    }
}