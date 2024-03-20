using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountEducation;
using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountEducation;

public class UserAccountEducationWriteRepository : WriteRepository<IdentityContext, Domain.Auth.UserAccountEducation>, IUserAccountEducationWriteRepository
{
    public UserAccountEducationWriteRepository(IdentityContext context) : base(context)
    {
    }
}