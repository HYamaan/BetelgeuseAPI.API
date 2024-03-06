using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Auth;

public class UserAccountInformation:BaseEntity
{
    public string AppUserId { get; set; }
    public string? Language { get; set; }
    public string? TimeZone { get; set; }
    public string? Currency { get; set; }
    public bool EmailNews { get; set; }
    public AppUser AppUser { get; set; }
    
}
