using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class CourseBasicInformation:BaseEntity
{
    public int Language { get; set; }
    public int CourseType { get; set; }
    public string Title { get; set; }
    public string SeoDescription { get; set; }
    public string Thumbnail { get; set; }
    public string CoverImage { get; set; }
    public string Description { get; set; }
}