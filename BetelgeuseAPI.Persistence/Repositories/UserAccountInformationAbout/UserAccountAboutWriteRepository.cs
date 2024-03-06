using BetelgeuseAPI.Application.Repositories.UserAccountInformationAbout;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountInformationAbout;

public class UserAccountAboutWriteRepository:WriteRepository<IdentityContext,Domain.Entities.UserAccountAbout>,IUserAccountAboutWriteRepository
{
    public UserAccountAboutWriteRepository(IdentityContext context) : base(context)
    {
    }
}