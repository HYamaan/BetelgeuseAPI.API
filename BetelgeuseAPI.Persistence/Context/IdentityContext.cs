using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Context
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<UserAccountInformation> UserAccountInformation { get; set; }
        public DbSet<UserAccountAbout> UserAccountInformationAbout { get; set; }
        public DbSet<UserAccountEducation> UserAccountEducations { get; set; }
        public DbSet<UserAccountExperiences> UserAccountExperiences { get; set; }
        public DbSet<AllUserSkills> AllUserSkills { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }

        public DbSet<Domain.Entities.File> File { get; set; }
        public DbSet<UserProfileImage> UserProfileImage { get; set; }
        public DbSet<UserProfileBackgroundImage> UserProfileBackgroundImage { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Identity");

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            modelBuilder.Seed();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.
            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var currentTime = DateTime.UtcNow;

                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = currentTime,
                    EntityState.Modified => data.Entity.UpdatedDate = currentTime,
                    _ => currentTime
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
