using BetelgeuseAPI.Application.DTOs.Request;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Entities.Course.Content;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class GetAllCoursesPage
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public Languages Language { get; set; }
    public CourseLevel CourseLevel { get; set; }
    public CourseClassType CourseType { get; set; }
    public string CoverImage { get; set; }
    public string ModeratorImage { get; set; }
    public string ModeratorName { get; set; }
    public string CourseTitle { get; set; }
    public int ReviewsCount { get; set; }
    public string CourseTime { get; set; }
    public string CreatedDate { get; set; }

    public int CoursePrice { get; set; }

    public bool IsFree { get; set; }
    public bool IsDownloadable { get; set; }

    public int Discount { get; set; }
    public bool IsDiscounted { get; set; }

    public List<SubTitleLanguageId>? CourseSubLanguages { get; set; }
}