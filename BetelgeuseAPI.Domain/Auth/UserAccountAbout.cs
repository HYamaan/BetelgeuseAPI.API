using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities;

public class UserAccountAbout:BaseEntity
{
    public string? AppUserId { get; set; }
    public string? Biography { get; set; }
    public string? JobTitle { get; set; }
    
    public AppUser AppUser;
}