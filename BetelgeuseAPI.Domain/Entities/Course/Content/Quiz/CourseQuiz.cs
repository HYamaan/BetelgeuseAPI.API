using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;

public class CourseQuiz : BaseEntity
{
    public Guid Language { get; set; }
    public required string Title { get; set; }
    public int? Time { get; set; }
    public int? Attempts { get; set; }
    public required int PassingScore { get; set; }
    public int? ExpiryDate { get; set; }

    public bool LimitedQuestion { get; set; }
    public int? QuestionCount { get; set; }
    public bool RandomizeQuestion { get; set; }
    public bool Certificate { get; set; }
    public bool IsActive { get; set; }

    public List<CourseQuestions> CourseQuestions { get; set; }
    public CourseSections CourseSections { get; set; }
}