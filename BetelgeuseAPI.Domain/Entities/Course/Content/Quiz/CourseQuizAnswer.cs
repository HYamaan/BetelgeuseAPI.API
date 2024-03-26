using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.File.Quiz;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;

public class CourseQuizAnswer:BaseEntity
{

    public string? Title { get; set; }
    public bool? IsCorrect { get; set; }

  
    public string? Description { get; set; }

    public Guid CourseQuestionId { get; set; }
    public CourseQuestions CourseQuestion { get; set; }
}