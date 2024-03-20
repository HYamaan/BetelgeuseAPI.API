using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Auth;

public class UserAccountEducation:BaseEntity
{
    public string AppUserId { get; set; }
    public string Education { get; set; }
    public AppUser AppUser { get; set; }    
}