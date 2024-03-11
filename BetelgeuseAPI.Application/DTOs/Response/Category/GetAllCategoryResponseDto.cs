namespace BetelgeuseAPI.Application.DTOs.Response.Category;

public class GetAllCategoryResponseDto
{
    public Guid? CategoryID { get; set; }
    public string Name { get; set; }
    public Guid? ParentCategoryID { get; set; }
    public string ParentCategoryName{ get; set; }
}