
namespace BetelgeuseAPI.Application.DTOs.Response.Blog
{
    public class BlogCategoryResponseDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string SubTitle { get; set; }
    }
}
