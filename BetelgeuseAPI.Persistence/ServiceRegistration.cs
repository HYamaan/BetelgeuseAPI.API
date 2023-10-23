using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories.File;
using BetelgeuseAPI.Persistence.Repositories.UserProfileImageFile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BetelgeuseAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BetelgeuseAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IUserProfileImageFileWriteRepository, UserProfileImageFileWriteRepository>();
            services.AddScoped<IUserProfileImageFileReadRepository, UserProfileImageFileReadRepository>();
        }
    }
}
