using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities;

public class UserSkills:BaseEntity
{
    public string AppUserId { get; set; }
    public Guid AllUserSkillsId { get; set; }
    public bool IsCheck { get; set; }
    public AllUserSkills AllUserSkills { get; set; }
    public AppUser AppUser {get; set; }
}