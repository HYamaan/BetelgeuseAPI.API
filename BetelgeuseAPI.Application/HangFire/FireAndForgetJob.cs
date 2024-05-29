using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.DTOs.Response.Purchases;
using BetelgeuseAPI.Domain.Entities.Purchase;

namespace BetelgeuseAPI.Application.HangFire;

public class FireAndForgetJob
{
    public static void SendCourseUpdatedNotifications(List<PurchasesSerializerDTO> purchases, string NotificationType, string m)
    {
        Hangfire.BackgroundJob.Enqueue<INotificationService>(x => x.SendCourseUpdatedNotifications(purchases, NotificationType, m));
    }

}