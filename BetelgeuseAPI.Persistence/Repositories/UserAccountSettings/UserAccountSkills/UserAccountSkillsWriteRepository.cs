using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountSkills;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountSkills
{
    public class UserAccountSkillsWriteRepository : WriteRepository<IdentityContext, Domain.Entities.User.UserSkills>,
        IUserAccountSkillsWriteRepository
    {
        public UserAccountSkillsWriteRepository(IdentityContext context) : base(context) { }
    }

}
