using BetelgeuseAPI.Application.Repositories.UserAccountInformation;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountInformation;

public class UserAccountInformationReadRepository:ReadRepository<IdentityContext,Domain.Auth.UserAccountInformation>
    ,IUserAccountInformationReadRepository
{
    public UserAccountInformationReadRepository(IdentityContext context) : base(context)
    {
    }
}