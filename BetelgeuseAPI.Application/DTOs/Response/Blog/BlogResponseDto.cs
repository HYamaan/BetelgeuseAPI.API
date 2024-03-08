
using BetelgeuseAPI.Domain.Entities;

namespace BetelgeuseAPI.Application.DTOs.Response.Blog
{
    public class BlogResponseDto
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }

        public required Guid BlogCategoriesID { get; set; }
        public string? Keywords { get; set; }
        public required string Description { get; set; }
        public required string Content { get; set; }
        public required Guid BlogImageID { get; set; }
        public BlogImage BlogImage { get; set; }
        public required string AppUserId { get; set; }
    }
}
