using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities;

public class UserSkills:BaseEntity
{
    public required string AppUserId { get; set; }
    public required string AllUserSkillsId{ get; set; }
    public required bool IsSkillsCheck { get; set; }
    public required AllUserSkills AllUserSkills{ get; set; }
    public required AppUser AppUser{ get; set; }
}