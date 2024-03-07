using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserProfileImageFile
{
    public class UserProfileImageFileWriteRepository : WriteRepository<IdentityContext,UserProfileImage>, IUserProfileImageFileWriteRepository
    {
        public UserProfileImageFileWriteRepository(IdentityContext context) : base(context)
        {
        }
    }
}
