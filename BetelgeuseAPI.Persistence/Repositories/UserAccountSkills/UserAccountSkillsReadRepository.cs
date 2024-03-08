
using BetelgeuseAPI.Application.Repositories.UserAccountSkills;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountSkills
{
    public class UserAccountSkillsReadRepository:ReadRepository<IdentityContext,Domain.Entities.UserSkills>,IUserAccountSkillsReadRepository
    {
        public UserAccountSkillsReadRepository(IdentityContext context) : base(context)
        {
        }
    }
}
