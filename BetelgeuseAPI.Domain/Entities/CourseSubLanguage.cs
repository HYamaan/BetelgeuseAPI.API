using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course;

namespace BetelgeuseAPI.Domain.Entities;

public class CourseSubLanguage:BaseEntity
{
    public int LanguageId { get; set; }
    public Guid CourseExtraInformationId { get; set; }
    public Language Language { get; set; }
    public CourseExtraInformation CourseExtraInformation { get; set; }
}