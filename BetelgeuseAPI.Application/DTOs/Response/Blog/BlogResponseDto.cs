using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;

namespace BetelgeuseAPI.Application.DTOs.Response.Blog
{
    public class BlogResponseDto
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }

        public required Guid BlogCategoriesID { get; set; }
        public required string Description { get; set; }
        public required string Content { get; set; }
        public required string Image { get; set; }
        public required string userEmailAddress { get; set; }
        public required string userName { get; set; }
  

        public MetaDataResponseDto MetaData { get; set; }
    }
}
