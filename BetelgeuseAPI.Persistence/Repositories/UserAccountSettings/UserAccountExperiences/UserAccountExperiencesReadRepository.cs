using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountExperiences;
using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountExperiences;

public class UserAccountExperiencesReadRepository : ReadRepository<IdentityContext, Domain.Auth.UserAccountExperiences>, IUserAccountExperiencesReadRepository
{
    public UserAccountExperiencesReadRepository(IdentityContext context) : base(context)
    {
    }
}