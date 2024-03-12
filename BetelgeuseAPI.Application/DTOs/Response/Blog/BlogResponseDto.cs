using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.DTOs.Response.Category;
using BetelgeuseAPI.Domain.Entities;
namespace BetelgeuseAPI.Application.DTOs.Response.Blog
{
    public class BlogResponseDto
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }

        public required Guid BlogCategoryID { get; set; }
        public required string Description { get; set; }
        public required string Content { get; set; }
        public required string BlogImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ViewCount { get; set; }  

        public BlogAppUserDto Author { get; set; }
        public GetAllCategoryResponseDto BlogCategory { get; set; }
        public MetaDataResponseDto MetaData { get; set; }
    }
}
