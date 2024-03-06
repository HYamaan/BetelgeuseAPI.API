using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories;

namespace BetelgeuseAPI.Application.Repositories.UserAccountExperiences;

public class UserAccountExperiencesReadRepository:ReadRepository<IdentityContext,Domain.Auth.UserAccountExperiences>,IUserAccountExperiencesReadRepository
{
    public UserAccountExperiencesReadRepository(IdentityContext context) : base(context)
    {
    }
}