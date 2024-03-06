using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserProfileImageFile
{
    public class UserProfileImageFileWriteRepository : WriteRepository<BetelgeuseAPIDbContext,UserProfileImage>, IUserProfileImageFileWriteRepository
    {
        public UserProfileImageFileWriteRepository(BetelgeuseAPIDbContext context) : base(context)
        {
        }
    }
}
