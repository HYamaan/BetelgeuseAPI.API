using BetelgeuseAPI.Application.Repositories.UserAccountInformationAbout;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountInformationAbout;

public class UserAccountAboutReadRepository:ReadRepository<IdentityContext,Domain.Entities.UserAccountAbout>,IUserAccountAboutReadRepository
{
    public UserAccountAboutReadRepository(IdentityContext context) : base(context)
    {
    }
}