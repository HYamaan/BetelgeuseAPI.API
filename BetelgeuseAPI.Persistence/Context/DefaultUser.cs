using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Persistence.Context
{
    public class DefaultUser
    {
        public static List<AppUser> IdentityUserList()
        {
            return new List<AppUser>()
            {
                new AppUser()
                {
                    Id = Constants.Student,
                    UserName = "student@gmail.com",
                    Email = "student@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    // Password@123
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==",
                    NormalizedEmail = "STUDENT@GMAIL.COM",
                    NormalizedUserName = "STUDENT@GMAIL.COM"
                },
                new AppUser()
                {
                    Id = Constants.Moderator,
                    UserName = "moderator@gmail.com",
                    Email = "moderator@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    // Password@123
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==",
                    NormalizedEmail = "MODERATOR@GMAIL.COM",
                    NormalizedUserName = "MODERATOR@GMAIL.COM"
                }
            };
        }
    }
}
