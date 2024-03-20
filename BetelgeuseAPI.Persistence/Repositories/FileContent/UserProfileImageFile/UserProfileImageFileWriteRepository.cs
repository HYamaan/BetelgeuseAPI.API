using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities.File;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.UserProfileImageFile
{
    public class UserProfileImageFileWriteRepository : WriteRepository<IdentityContext, UserProfileImage>, IUserProfileImageFileWriteRepository
    {
        public UserProfileImageFileWriteRepository(IdentityContext context) : base(context)
        {
        }
    }
}
