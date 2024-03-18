using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BetelgeuseAPI.Persistence.Context
{
    public class BetelgeuseAPIDbContext : DbContext
    {
        public BetelgeuseAPIDbContext(DbContextOptions<BetelgeuseAPIDbContext> options) : base(options) { }



        public DbSet<CourseParentSubTopic> CourseParentSubTopics { get; set; }
        public DbSet<CourseChildSubTopic> CourseChildSubTopics { get; set; }
        public DbSet<CourseVideoSubTopic> CourseVideoSubTopics { get; set; }


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