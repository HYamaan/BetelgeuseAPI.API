using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.DTOs.Response.Category;
using BetelgeuseAPI.Domain.Entities;
namespace BetelgeuseAPI.Application.DTOs.Response.Blog
{
    public class BlogResponseDto
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }

        public  Guid BlogCategoryID { get; set; }
        public  string Description { get; set; }
        public  string Content { get; set; }
        public  string BlogImage { get; set; }
        public string CreatedDate { get; set; }
        public int ViewCount { get; set; }  

        public BlogAppUserDto Author { get; set; }
        public GetAllCategoryResponseDto BlogCategory { get; set; }
        public MetaDataResponseDto MetaData { get; set; }
    }
}
