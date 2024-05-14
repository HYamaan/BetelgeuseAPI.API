namespace BetelgeuseAPI.Application.DTOs.Response.Blog;

public class GetPanelBlogEditResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Keywords { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public string BlogImage { get; set; }
}