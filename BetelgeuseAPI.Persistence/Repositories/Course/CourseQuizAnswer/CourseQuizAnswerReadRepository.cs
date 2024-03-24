using BetelgeuseAPI.Application.Repositories.Course.CourseQuizAnswer;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseQuizAnswer;

public class CourseQuizAnswerReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.Content.Quiz.CourseQuizAnswer>, ICourseQuizAnswerReadRepository
{
    public CourseQuizAnswerReadRepository(IdentityContext context) : base(context)
    {
    }
}