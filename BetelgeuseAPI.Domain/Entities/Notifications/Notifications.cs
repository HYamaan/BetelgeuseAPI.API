using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Notifications;

public class Notification : BaseEntity
{
    public string UserId { get; set; } // Bildirimin gönderildiği kullanıcının ID'si
    public string Title { get; set; } // Bildirim başlığı
    public string Message { get; set; } // Bildirim mesajı
    public bool IsRead { get; set; } // Okunma durumu

    // Kullanıcıyla ilişkilendirme (User sınıfı varsayılarak yazılmıştır)
    public virtual AppUser User { get; set; }

    public Notification()
    {
        IsRead = false; // Varsayılan olarak okunmamış olarak işaretlenir
    }
}
