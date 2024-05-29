using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course.CourseDetail;

public class CourseInformationResponseDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CourseTitle { get; set; }
    public int CourseRating { get; set; }
    public int CourseReviewsCount { get; set; }
    public string CourseDescription { get; set; }
    public List<string> Tags { get; set; }

    public List<string> LearningMaterials { get; set; }
    public List<string> CourseLogo { get; set; }
    public List<string> CourseRequirements { get; set; }
    public List<Faq> CourseFaq { get; set; }
    public int Price { get; set; }
    public bool IsFree { get; set; }

    public Languages Language { get; set; }
    public List<int>? SubTitleLanguages { get; set; }
    public CourseLevel CourseLevel { get; set; }

    public int? Discount { get; set; }
    public int? DiscountedPrice { get; set; }
    public DateTime? DiscountEndDate { get; set; }
}