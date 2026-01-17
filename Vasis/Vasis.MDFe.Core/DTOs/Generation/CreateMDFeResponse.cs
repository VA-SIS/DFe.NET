namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class CreateMDFeResponse
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string XmlContent { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}