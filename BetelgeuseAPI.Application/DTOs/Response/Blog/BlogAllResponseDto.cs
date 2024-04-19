namespace BetelgeuseAPI.Application.DTOs.Response.Blog;

public class BlogAllResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid BlogCategoryId { get; set; }
    public string Content { get; set; }
    public string BlogImage { get; set; }
    public string CreatedDate { get; set; }
    public int ViewCount { get; set; }
    public string AuthorName { get; set; }
    public int ReviewCount { get; set; }
}