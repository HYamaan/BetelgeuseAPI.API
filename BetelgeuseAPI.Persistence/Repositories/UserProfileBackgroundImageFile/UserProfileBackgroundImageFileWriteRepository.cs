

using BetelgeuseAPI.Application.Repositories.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserProfileBackgroundImageFile
{
    public class UserProfileBackgroundImageFileWriteRepository : WriteRepository<IdentityContext,UserProfileBackgroundImage>, 
        IUserProfileBackgroundImageFileWriteRepository
    {
        public UserProfileBackgroundImageFileWriteRepository(IdentityContext context) : base(context)
        {
        }
    }
}
