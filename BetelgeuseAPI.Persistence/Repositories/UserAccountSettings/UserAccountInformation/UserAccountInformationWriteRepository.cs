using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountInformation;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories.UserSettings.UserAccountInformation;

public class UserAccountInformationWriteRepository : WriteRepository<IdentityContext, Domain.Auth.UserAccountInformation>
    , IUserAccountInformationWriteRepository
{
    public UserAccountInformationWriteRepository(IdentityContext context) : base(context)
    {
    }
}