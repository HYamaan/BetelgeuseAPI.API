
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Entities;
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
            Language(modelBuilder);
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
        private static void Language(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = Guid.Parse("a2148c9c-f647-48e9-bbc6-23ebecc0f871"), IsPrimary = true, Name = "Türkçe", SeoCode = "tr", Published = true },
                new Language { Id = Guid.Parse("710dd364-ce6f-4de3-abf5-2bc8cf9a1ee7"), IsPrimary = false, Name = "İngilizce", SeoCode = "en", Published = true }
            );
        }
    }
}
