using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Repositories.NotificationService;
using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Persistence.Repositories.Notification;
using BetelgeuseAPI.Persistence.Repositories.UserAccountSkill;
using BetelgeuseAPI.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BetelgeuseAPI.Persistence;

public static class NotificationRegistration
{
    public static void NotificationServices(this IServiceCollection services)
    {
        services.AddScoped<INotificationService, NotificationService>();

       services.AddScoped<INotificationReadRepository,NotificationReadRepository>();
       services.AddScoped<INotificationWriteRepository,NotificationWriteRepository>();

    }
}