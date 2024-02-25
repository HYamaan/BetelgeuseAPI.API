using BetelgeuseAPI.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace BetelgeuseAPI.Persistence.Context
{
    public class MappingUserRole
    {
        public static List<IdentityUserRole<string>> IdentityUserRoleList()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    UserId = Constants.Moderator,
                    RoleId = Constants.Moderator
                },
                new IdentityUserRole<string>()
                {
                    UserId = Constants.Student,
                    RoleId = Constants.Student
                }
            };
        }
    }
}
