using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories;

namespace BetelgeuseAPI.Application.Repositories.UserAccountEducation;

public class UserAccountEducationWriteRepository:WriteRepository<IdentityContext,Domain.Auth.UserAccountEducation>,IUserAccountEducationWriteRepository
{
    public UserAccountEducationWriteRepository(IdentityContext context) : base(context)
    {
    }
}