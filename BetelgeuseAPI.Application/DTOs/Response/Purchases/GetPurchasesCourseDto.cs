namespace BetelgeuseAPI.Application.DTOs.Response.Purchases;

public class GetPurchasesCourseDto
{
    public Guid Id { get; set; }
    public string CourseType { get; set; }
    public string Image { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public double UserPointAvarage { get; set; }
    public string Duration { get; set; }
    public string UpdateTime { get; set; }
    public string Category { get; set; }
    public string Price { get; set; }
    public string DiscountedPrice { get; set; }
    public bool IsDownloadable { get; set; }
}