using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Purchases;

public class ShoppingCartDto
{
    public Guid Id { get; set; }
    public string Image { get; set; }
    public string Title { get; set; }

    public string AuthorId { get; set; }
    public string AuthorName { get; set; }
    public double UserPointAvarage { get; set; }
    public double UserPointCount { get; set; }

    public float Price { get; set; }
    public float? DiscountedPrice { get; set; }

    public int Time { get; set; }
    public int CourseSectionCount { get; set; }
    public CourseLevel CourseLevel { get; set; }
}