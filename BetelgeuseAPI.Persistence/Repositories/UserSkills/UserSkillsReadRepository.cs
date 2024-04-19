using BetelgeuseAPI.Application.Repositories.UserSkills;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserSkills;

public class UserSkillsReadRepository:ReadRepository<IdentityContext,Domain.Entities.User.UserSkills>,IUserSkillsReadRepository
{
    public UserSkillsReadRepository(IdentityContext context) : base(context)
    {
    }
}