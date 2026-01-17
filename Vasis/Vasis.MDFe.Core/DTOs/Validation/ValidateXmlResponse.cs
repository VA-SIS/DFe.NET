namespace Vasis.MDFe.Application.DTOs.Validation
{
    public class ValidateXmlResponse
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();
        public string Message { get; set; }
        public DateTime ValidatedAt { get; set; } = DateTime.UtcNow;
    }
}