using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories;

namespace BetelgeuseAPI.Application.Repositories.UserAccountEducation;

public class UserAccountEducationReadRepository:ReadRepository<IdentityContext,Domain.Auth.UserAccountEducation>,IUserAccountEducationReadRepository
{
    public UserAccountEducationReadRepository(IdentityContext context) : base(context)
    {
    }
}