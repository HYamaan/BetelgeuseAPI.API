
using BetelgeuseAPI.Application.Repositories.UserRefreshToken;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserRefreshToken
{
    public class UserRefreshTokenReadRepository : ReadRepository<IdentityContext,Domain.Auth.RefreshToken>,
        IUserRefreshTokenReadRepository
    {
        public UserRefreshTokenReadRepository(IdentityContext context) : base(context)
        {

        }
    }
}
