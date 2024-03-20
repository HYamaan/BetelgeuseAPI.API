using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities.File;
using BetelgeuseAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.UserProfileImageFile
{
    public class UserProfileImageFileReadRepository : ReadRepository<IdentityContext, UserProfileImage>, IUserProfileImageFileReadRepository
    {
        public UserProfileImageFileReadRepository(IdentityContext context) : base(context)
        {
        }
    }
}
