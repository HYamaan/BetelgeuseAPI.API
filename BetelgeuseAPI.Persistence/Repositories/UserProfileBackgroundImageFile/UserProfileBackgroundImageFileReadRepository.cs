
using BetelgeuseAPI.Application.Repositories.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserProfileBackgroundImageFile
{
    public class UserProfileBackgroundImageFileReadRepository : ReadRepository<IdentityContext,UserProfileBackgroundImage>,
        IUserProfileBackgroundImageFileReadRepository
    {
        public UserProfileBackgroundImageFileReadRepository(IdentityContext context) : base(context)
        {
        }
    }
}
