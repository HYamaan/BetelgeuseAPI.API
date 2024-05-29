using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.DTOs.Response.Purchases;
using BetelgeuseAPI.Application.Repositories.NotificationService;
using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Domain.Entities.Notifications;
using BetelgeuseAPI.Domain.Entities.Purchase;
using BetelgeuseAPI.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Services;

public class NotificationService:INotificationService
{
    private readonly INotificationWriteRepository _writeRepository;
    private readonly INotificationReadRepository _readRepository;

    public NotificationService(INotificationWriteRepository writeRepository, INotificationReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }



    public async Task SendAsync(string userId, string title, string message)
    {
        var notification = new Notification
        {
            UserId = userId,
            Title = title,
            Message = message,
        };

        await _writeRepository.AddAsync(notification);
        await _writeRepository.SaveAsync();
    }
    public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(string userId)
    {
        return await _readRepository.GetWhere(n => n.UserId == userId && !n.IsRead).ToListAsync();
    }

    public async Task MarkAsReadAsync(Guid notificationId)
    {
        var notification = await _readRepository.GetByIdAsync(notificationId.ToString());
        if (notification != null && !notification.IsRead)
        {
            notification.IsRead = true;
            _writeRepository.Update(notification);
            await _writeRepository.SaveAsync();
        }
    }
    public async Task SendCourseUpdatedNotifications(List<PurchasesSerializerDTO> purchases, string NotificationType, string m)
    {
        if (purchases == null)
            return;

        foreach (var purchase in purchases)
        {
            string message = GenerateMessageForNotification(NotificationType, m);
            await SendAsync(purchase.UserId, NotificationsTitleStrings.UpdatedCourse, message);
            
        }
    }

    private string GenerateMessageForNotification(string notificationType, string additionalInfo)
    {
        switch (notificationType)
        {
            case NotificationsTitleStrings.NewRewardPoint:
                return $"You have earned a new reward point for {additionalInfo}.";
            case NotificationsTitleStrings.NewPurchaseCompleted:
                return $"Your purchase of {additionalInfo} has been completed successfully.";
            case NotificationsTitleStrings.NewMeetingRequest:
                return $"You have a new meeting request regarding {additionalInfo}.";
            case NotificationsTitleStrings.WaitingQuizResult:
                return $"Your quiz results for {additionalInfo} are pending.";
            case NotificationsTitleStrings.UpdatedQuizResult:
                return $"Your quiz results for {additionalInfo} have been updated.";
            case NotificationsTitleStrings.UpdatedCourse:
                return $"{additionalInfo} course you purchased has been updated.";
            default:
                return "You have a new notification.";
        }
    }

}