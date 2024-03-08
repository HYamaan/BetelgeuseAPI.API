
using BetelgeuseAPI.Application.Repositories.UserAccountSkills;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountSkills
{
    public class UserAccountSkillsWriteRepository : WriteRepository<IdentityContext, Domain.Entities.UserSkills>,
        IUserAccountSkillsWriteRepository
    {
        public UserAccountSkillsWriteRepository(IdentityContext context) : base(context){}
    }
    
}
