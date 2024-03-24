using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;

namespace BetelgeuseAPI.Domain.Entities.Course.Content;

public class CourseSections:BaseEntity
{
    public Guid LanguageId { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public bool PassAllParts { get; set; }
    public List<CourseSource>? CourseSources { get; set; }
    public List<CourseQuiz>? CourseQuizzes { get; set; }
}