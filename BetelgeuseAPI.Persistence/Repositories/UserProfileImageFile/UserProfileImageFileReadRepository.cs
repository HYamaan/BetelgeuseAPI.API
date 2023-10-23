using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Persistence.Repositories.UserProfileImageFile
{
    public class UserProfileImageFileReadRepository : ReadRepository<UserProfileImage>,IUserProfileImageFileReadRepository
    {
        public UserProfileImageFileReadRepository(BetelgeuseAPIDbContext context) : base(context)
        {
        }
    }
}
