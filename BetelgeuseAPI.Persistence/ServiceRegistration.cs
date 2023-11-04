using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.User;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Application.Repositories.VideoUploadFile;
using BetelgeuseAPI.Persistence.Context;
using BetelgeuseAPI.Persistence.Repositories.File;
using BetelgeuseAPI.Persistence.Repositories.User;
using BetelgeuseAPI.Persistence.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Persistence.Repositories.VideoUploadFile;
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
            services.AddScoped<IVideoUploadFileWriteRepository, VideoUploadFileWriteRepository>();
            services.AddScoped<IVideoUploadFileReadRepository, VideoUploadFileReadRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        }
    }
}