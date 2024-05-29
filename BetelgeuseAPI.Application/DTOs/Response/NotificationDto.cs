namespace BetelgeuseAPI.Application.DTOs.Response;

public class NotificationDto
{
    public string Title { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public string Date { get; set; }
    public string Clock { get; set; }
}