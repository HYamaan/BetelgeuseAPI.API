using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace BetelgeuseAPI.Persistence.Context
{
    public class BetelgeuseAPIDbContext : DbContext
    {
        public BetelgeuseAPIDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<UserProfileImage> ProductImageFiles { get; set; }
        public DbSet<VideoUploadModel> VideoUploadFiles { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.
            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}