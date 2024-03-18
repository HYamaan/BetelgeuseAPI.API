using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountAbout;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountInformationAbout;

public class UserAccountAboutReadRepository : ReadRepository<IdentityContext, Domain.Entities.UserAccountAbout>, IUserAccountAboutReadRepository
{
    public UserAccountAboutReadRepository(IdentityContext context) : base(context)
    {
    }
}