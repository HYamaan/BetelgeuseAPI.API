using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Auth;

public class UserAccountExperiences:BaseEntity
{
    public string AppUserId { get; set; }
    public string Experiences { get; set; }
    public AppUser AppUser { get; set; }
    
}