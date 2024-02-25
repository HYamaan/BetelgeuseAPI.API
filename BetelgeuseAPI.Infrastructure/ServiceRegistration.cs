
using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Abstractions.Token;
using BetelgeuseAPI.Domain.Settings;
using BetelgeuseAPI.Infrastructure.Enums;
using BetelgeuseAPI.Infrastructure.Extension;
using BetelgeuseAPI.Infrastructure.Services;
using BetelgeuseAPI.Infrastructure.Services.Storage;
using BetelgeuseAPI.Infrastructure.Services.Storage.Azure;
using BetelgeuseAPI.Infrastructure.Services.Storage.Local;
using BetelgeuseAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BetelgeuseAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            
            serviceCollection.AddSwaggerOpenAPI();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:

                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }

    }
}
