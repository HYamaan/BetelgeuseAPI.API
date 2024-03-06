using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories;

namespace BetelgeuseAPI.Application.Repositories.UserAccountExperiences;

public class UserAccountExperiencesWriteRepository:WriteRepository<IdentityContext,Domain.Auth.UserAccountExperiences>
    ,IUserAccountExperiencesWriteRepository
{
    public UserAccountExperiencesWriteRepository(IdentityContext context) : base(context)
    {
    }
}