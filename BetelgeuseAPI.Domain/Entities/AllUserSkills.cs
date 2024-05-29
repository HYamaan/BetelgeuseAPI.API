using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.User;

namespace BetelgeuseAPI.Domain.Entities;

public class AllUserSkills : BaseEntity
{
    public string Skill { get; set; }
    public bool IsCheck { get; set; }

    public UserSkills UserSkills { get; set; }
}