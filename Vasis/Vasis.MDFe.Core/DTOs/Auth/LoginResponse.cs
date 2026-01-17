namespace Vasis.MDFe.Application.DTOs.Auth
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Message { get; set; }
    }
}