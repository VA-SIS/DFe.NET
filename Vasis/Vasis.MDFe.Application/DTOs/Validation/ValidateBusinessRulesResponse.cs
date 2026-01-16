namespace Vasis.MDFe.Application.DTOs.Validation
{
    public class ValidateBusinessRulesResponse
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new();
        public List<string> Warnings { get; set; } = new();
        public string Message { get; set; }
        public DateTime ValidatedAt { get; set; } = DateTime.UtcNow;
    }
}