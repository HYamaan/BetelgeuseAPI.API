using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Domain.Entities.Notifications;
using BetelgeuseAPI.Domain.Entities.Purchase;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface INotificationService
{
    Task SendCourseUpdatedNotifications(InclusiveCourse course, string NotificationType, string m);
    Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(string userId);
    Task SendAsync(string userId,string title ,string message);
}