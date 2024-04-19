using BetelgeuseAPI.Application.DTOs.Response;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.GetNotifications;

public class GetNotificationsCommandResponse:ResponseMessageAndSucceeded
{
    public List<NotificationDto> Data { get; set; }
    
}