using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountEducation;
using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountEducation;

public class UserAccountEducationReadRepository : ReadRepository<IdentityContext, Domain.Auth.UserAccountEducation>, IUserAccountEducationReadRepository
{
    public UserAccountEducationReadRepository(IdentityContext context) : base(context)
    {
    }
}