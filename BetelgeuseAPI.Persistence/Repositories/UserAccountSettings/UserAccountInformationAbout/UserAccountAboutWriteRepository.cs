using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountAbout;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountInformationAbout;

public class UserAccountAboutWriteRepository : WriteRepository<IdentityContext, Domain.Entities.UserAccountAbout>, IUserAccountAboutWriteRepository
{
    public UserAccountAboutWriteRepository(IdentityContext context) : base(context)
    {
    }
}