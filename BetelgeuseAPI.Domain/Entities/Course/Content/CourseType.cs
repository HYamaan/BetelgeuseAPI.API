using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;

namespace BetelgeuseAPI.Domain.Entities.Course.Content;

public class CourseType:BaseEntity
{
    public int Order { get; set; }
    public Guid? CourseSourcesId { get; set; }
    public Guid? CourseQuizzesId { get; set; }
    public CourseSource? CourseSources { get; set; }
    public CourseQuiz? CourseQuizzes { get; set; }

}