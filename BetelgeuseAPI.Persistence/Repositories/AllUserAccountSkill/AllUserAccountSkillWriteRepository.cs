using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountSkill;

public class AllUserAccountSkillWriteRepository:WriteRepository<BetelgeuseAPIDbContext,AllUserSkills>,IAllUserAccountSkillWriteRepository
{
    public AllUserAccountSkillWriteRepository(BetelgeuseAPIDbContext context) : base(context)
    {
    }
}