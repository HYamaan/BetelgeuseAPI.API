using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.File.Quiz;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;

public class CourseQuestions:BaseEntity
{
    public Guid LanguageId { get; set; }
    public required string Title { get; set; }
    public required int Grade { get; set; }
    public CourseQuizQuestionType QuestionType { get; set; }
    public List<CourseQuizQuestionVideo>? Video { get; set; }
    public CourseQuizQuestionImage? Image { get; set; }
  

    public List<CourseQuizAnswer> CourseQuizAnswers { get; set; }
    public Guid CourseQuizId { get; set; }
    public CourseQuiz CourseQuiz { get; set; }
}