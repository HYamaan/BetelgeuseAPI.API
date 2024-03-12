
using BetelgeuseAPI.Domain.Entities;

namespace BetelgeuseAPI.Application.DTOs.Response.Account
{
    public class BlogAppUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string slug { get; set; }
        public List<UserProfileImage> Image { get; set; }
    }
}
