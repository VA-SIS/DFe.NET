namespace Vasis.MDFe.Application.DTOs.Generation
{
    public class SignMDFeResponse
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string XmlSigned { get; set; }
        public string Message { get; set; }
        public DateTime SignedAt { get; set; } = DateTime.UtcNow;
    }
}