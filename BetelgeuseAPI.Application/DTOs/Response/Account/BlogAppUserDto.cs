using BetelgeuseAPI.Domain.Entities.File;

namespace BetelgeuseAPI.Application.DTOs.Response.Account
{
    public class BlogAppUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string slug { get; set; }
        public string Image { get; set; }
    }
}
