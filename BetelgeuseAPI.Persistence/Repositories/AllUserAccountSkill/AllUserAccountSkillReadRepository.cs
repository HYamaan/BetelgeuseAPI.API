using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountSkill;

public class AllUserAccountSkillReadRepository:ReadRepository<IdentityContext,AllUserSkills>, IAllUserAccountSkillReadRepository
{
    public AllUserAccountSkillReadRepository(IdentityContext context) : base(context)
    {
    }
}