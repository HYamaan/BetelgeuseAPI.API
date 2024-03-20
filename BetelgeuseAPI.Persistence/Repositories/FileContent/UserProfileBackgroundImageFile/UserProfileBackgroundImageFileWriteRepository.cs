using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Domain.Entities.File;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.UserProfileBackgroundImageFile
{
    public class UserProfileBackgroundImageFileWriteRepository : WriteRepository<IdentityContext, UserProfileBackgroundImage>,
        IUserProfileBackgroundImageFileWriteRepository
    {
        public UserProfileBackgroundImageFileWriteRepository(IdentityContext context) : base(context)
        {
        }
    }
}
