using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course.Content;

public class CourseContent : BaseEntity
{
    public List<CourseSections> Sections { get; set; }
}