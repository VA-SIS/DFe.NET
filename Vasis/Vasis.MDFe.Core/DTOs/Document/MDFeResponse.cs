namespace Vasis.MDFe.Application.DTOs.Document
{
    public class MDFeResponse
    {
        public bool Success { get; set; }
        public string ChaveAcesso { get; set; }
        public string XmlContent { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}