using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;

public class CourseQuiz : BaseEntity
{
    public int Order { get; set; }
    public Languages Language { get; set; }
    public required string Title { get; set; }
    public int Time { get; set; }
    public int? Attempts { get; set; }
    public required int PassingScore { get; set; }
    public int? ExpiryDate { get; set; }

    public bool LimitedQuestion { get; set; }
    public int? QuestionCount { get; set; }
    public bool RandomizeQuestion { get; set; }
    public bool Certificate { get; set; }
    public bool IsActive { get; set; }

    public ICollection<CourseQuestions>? CourseQuestions { get; set; }
    public CourseSections CourseSections { get; set; }
}