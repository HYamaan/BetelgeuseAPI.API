namespace BetelgeuseAPI.Application.Abstractions.Services;

    public interface IMailService
    {
        Task SendPasswordResetMailAsync(string to, string userId, string resetToken, string endPoint);
    }