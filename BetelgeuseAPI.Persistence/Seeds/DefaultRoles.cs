using BetelgeuseAPI.Domain.Enum;
using BetelgeuseAPI.Domain.Auth;

namespace BetelgeuseAPI.Persistence.Seeds
{
    public static class DefaultRoles
    {
        public static List<AppRole> IdentityRoleList()
        {
            return new List<AppRole>()
            {
                new AppRole
                {
                    Id = Constants.Admin,
                    Name = Roles.Admin.ToString(),
                    NormalizedName = Roles.Admin.ToString()
                },
                new AppRole
                {
                    Id = Constants.Moderator,
                    Name = Roles.Moderator.ToString(),
                    NormalizedName = Roles.Moderator.ToString()
                },
                new AppRole
                {
                    Id = Constants.Student,
                    Name = Roles.Student.ToString(),
                    NormalizedName = Roles.Student.ToString()
                }
            };
        }
    }
}
