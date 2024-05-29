using BetelgeuseAPI.Application.Repositories.UserSkills;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserSkills;

public class UserSkillsWriteRepository:WriteRepository<IdentityContext,Domain.Entities.User.UserSkills>,IUserSkillsWriteRepository
{
    public UserSkillsWriteRepository(IdentityContext context) : base(context)
    {
    }
}