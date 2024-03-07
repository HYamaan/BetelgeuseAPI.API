using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountSkill;

public class AllUserAccountSkillReadRepository:ReadRepository<BetelgeuseAPIDbContext,AllUserSkills>, IAllUserAccountSkillReadRepository
{
    public AllUserAccountSkillReadRepository(BetelgeuseAPIDbContext context) : base(context)
    {
    }
}