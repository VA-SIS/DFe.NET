using Vasis.MDFe.Core.Entities.Common;

namespace Vasis.MDFe.Core.Entities.Auth;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginAt { get; set; }
    public ICollection<string> Roles { get; set; } = new List<string>();
}