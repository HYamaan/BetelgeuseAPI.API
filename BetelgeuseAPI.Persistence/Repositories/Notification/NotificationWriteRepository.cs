using BetelgeuseAPI.Application.Repositories.NotificationService;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Notification;

public class NotificationWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Notifications.Notification>,INotificationWriteRepository
{
    public NotificationWriteRepository(IdentityContext context) : base(context)
    {
    }
}