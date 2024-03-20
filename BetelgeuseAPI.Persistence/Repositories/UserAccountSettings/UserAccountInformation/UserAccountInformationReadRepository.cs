using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountInformation;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountInformation;

public class UserAccountInformationReadRepository : ReadRepository<IdentityContext, Domain.Auth.UserAccountInformation>
    , IUserAccountInformationReadRepository
{
    public UserAccountInformationReadRepository(IdentityContext context) : base(context)
    {
    }
}