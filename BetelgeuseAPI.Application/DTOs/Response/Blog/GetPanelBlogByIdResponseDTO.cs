namespace BetelgeuseAPI.Application.DTOs.Response.Blog;

public class GetPanelBlogByIdResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public int Comments { get; set; }
    public int Views { get; set; }
    public string Status { get; set; }
    public string CreatedAt { get; set; }
}