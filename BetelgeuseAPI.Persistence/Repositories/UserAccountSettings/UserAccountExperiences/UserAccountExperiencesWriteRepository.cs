using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountExperiences;
using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountExperiences;

public class UserAccountExperiencesWriteRepository : WriteRepository<IdentityContext, Domain.Auth.UserAccountExperiences>
    , IUserAccountExperiencesWriteRepository
{
    public UserAccountExperiencesWriteRepository(IdentityContext context) : base(context)
    {
    }
}