using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class BasicInformationResponseDto
{
    public Guid CourseId { get; set; }
    public Languages Language { get; set; }
    public CourseClassType CourseType { get; set; }
    public string Title { get; set; }
    public string SeoDescription { get; set; }
    public string Thumbnail { get; set; }
    public string CoverImage { get; set; }
    public string Description { get; set; }
}