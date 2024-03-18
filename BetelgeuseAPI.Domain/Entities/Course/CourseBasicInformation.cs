using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.File;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class CourseBasicInformation:BaseEntity
{
    public Guid Language { get; set; }
    public int CourseType { get; set; }
    public string Title { get; set; }
    public string SeoDescription { get; set; }
    public CourseThumbnail Thumbnail { get; set; }
    public CourseCoverImage CoverImage { get; set; }
    public string Description { get; set; }

    
}