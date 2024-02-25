using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Seeds
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            CreateRoles(modelBuilder);
            CreateBasicUsers(modelBuilder);
            MapUserRole(modelBuilder);
        }

        private static void CreateRoles(ModelBuilder modelBuilder)
        {
            List<AppRole> roles = DefaultRoles.IdentityRoleList();
            modelBuilder.Entity<AppRole>().HasData(roles);
        }
        private static void CreateBasicUsers(ModelBuilder modelBuilder)
        {
            List<AppUser> users = DefaultUser.IdentityUserList();
            modelBuilder.Entity<AppUser>().HasData(users);
        }
        private static void MapUserRole(ModelBuilder modelBuilder)
        {
            var identityUserRoles = MappingUserRole.IdentityUserRoleList();
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityUserRoles);
        }
    }
}
