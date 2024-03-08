using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountSkill;

public class AllUserAccountSkillWriteRepository:WriteRepository<IdentityContext,AllUserSkills>,IAllUserAccountSkillWriteRepository
{
    public AllUserAccountSkillWriteRepository(IdentityContext context) : base(context)
    {
    }
}