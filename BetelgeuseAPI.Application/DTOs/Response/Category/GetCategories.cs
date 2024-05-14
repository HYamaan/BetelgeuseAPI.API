namespace BetelgeuseAPI.Application.DTOs.Response.Category;

public class GetCategories
{
    public Guid? ParentCategoryID { get; set; }
    public string ParentCategoryName { get; set; }

    public List<Categories> Categories { get; set; }
}