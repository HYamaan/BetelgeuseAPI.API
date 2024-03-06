using BetelgeuseAPI.Application.Repositories.UserAccountInformation;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories.UserAccountInformation;

public class UserAccountInformationWriteRepository:WriteRepository<IdentityContext,Domain.Auth.UserAccountInformation>
    ,IUserAccountInformationWriteRepository
{
    public UserAccountInformationWriteRepository(IdentityContext context) : base(context)
    {
    }
}