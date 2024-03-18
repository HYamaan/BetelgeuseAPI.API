
using BetelgeuseAPI.Application.Repositories.UserRefreshToken;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserRefreshToken
{
    public class UserRefreshTokenWriteRepository:WriteRepository<IdentityContext,Domain.Auth.RefreshToken>,IUserRefreshTokenWriteRepository
    {
        public UserRefreshTokenWriteRepository(IdentityContext context) : base(context)
        {
        }
    }
}
