using BetelgeuseAPI.Application.Repositories.NotificationService;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Notification;

public class NotificationReadRepository:ReadRepository<IdentityContext,Domain.Entities.Notifications.Notification>,INotificationReadRepository
{
    public NotificationReadRepository(IdentityContext context) : base(context)
    {
    }
}