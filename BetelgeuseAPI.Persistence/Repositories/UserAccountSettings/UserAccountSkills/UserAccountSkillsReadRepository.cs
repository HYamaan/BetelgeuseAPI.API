using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountSkills;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountSkills
{
    public class UserAccountSkillsReadRepository : ReadRepository<IdentityContext, Domain.Entities.User.UserSkills>, IUserAccountSkillsReadRepository
    {
        public UserAccountSkillsReadRepository(IdentityContext context) : base(context)
        {
        }
    }
}
