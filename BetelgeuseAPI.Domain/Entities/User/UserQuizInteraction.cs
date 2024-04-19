using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;

namespace BetelgeuseAPI.Domain.Entities.User;

public class UserQuizInteraction : BaseEntity
{
    public bool IsPassed { get; set; }
    public bool IsCompleted { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }

    public Guid CourseQuizId { get; set; }
    public CourseQuiz CourseQuiz { get; set; }

    public Guid CourseQuestionId { get; set; }
    public CourseQuestions CourseQuestion { get; set; } 

    public Guid? CourseQuizAnswerId { get; set; }
    public CourseQuizAnswer? CourseQuizAnswer { get; set; }
}
