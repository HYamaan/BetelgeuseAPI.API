using System.ComponentModel.DataAnnotations.Schema;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.File.Quiz;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;

public class CourseQuestions:BaseEntity
{
    public Languages LanguageId { get; set; }
    public  string Title { get; set; }
    public required int Grade { get; set; }
    public CourseQuizQuestionType QuestionType { get; set; }
    public ICollection<CourseQuizUpload>? Video { get; set; }

    public CourseQuizUpload? Image { get; set; }
  

    public ICollection<CourseQuizAnswer> CourseQuizAnswers { get; set; }
    public Guid CourseQuizId { get; set; }
    public CourseQuiz CourseQuiz { get; set; }
}