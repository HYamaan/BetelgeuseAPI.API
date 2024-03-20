using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Domain.Entities.File;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.UserProfileBackgroundImageFile
{
    public class UserProfileBackgroundImageFileReadRepository : ReadRepository<IdentityContext, UserProfileBackgroundImage>,
        IUserProfileBackgroundImageFileReadRepository
    {
        public UserProfileBackgroundImageFileReadRepository(IdentityContext context) : base(context)
        {
        }
    }
}
