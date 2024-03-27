using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Repositories.Purchase;
using BetelgeuseAPI.Persistence.Repositories.Course.Purchase;
using BetelgeuseAPI.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class PurchaseRegistration
{
    public static void AddPurchaseService(this IServiceCollection services)
    {
        services.AddScoped<IPurchaseService, PurchaseService>();
        services.AddScoped<IPurchaseReadRepository, PurchaseReadRepository>();
        services.AddScoped<IPurchaseWriteRepository, PurchaseWriteRepository>();

    }
}