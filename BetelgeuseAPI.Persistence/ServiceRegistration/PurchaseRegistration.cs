using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Repositories.CourseFavorite;
using BetelgeuseAPI.Application.Repositories.Purchase;
using BetelgeuseAPI.Application.Repositories.ShoppingCartItem;
using BetelgeuseAPI.Persistence.Repositories.Course.Purchase;
using BetelgeuseAPI.Persistence.Repositories.CourseFavorite;
using BetelgeuseAPI.Persistence.Repositories.ShoppingCartItem;
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

        services.AddScoped<ICourseFavoriteReadRepository, CourseFavoriteReadRepository>();
        services.AddScoped<ICourseFavoriteWriteRepository, CourseFavoriteWriteRepository>();

        services.AddScoped<IShoppingCartItemReadRepository, ShoppingCartItemReadRepository>();
        services.AddScoped<IShoppingCartItemWriteRepository, ShoppingCartItemWriteRepository>();
    }
}