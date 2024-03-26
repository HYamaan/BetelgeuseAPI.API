using BetelgeuseAPI.Application.Repositories.Course.CourseQuizAnswer;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseQuizAnswer;

public class CourseQuizAnswerWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.Content.Quiz.CourseQuizAnswer>, ICourseQuizAnswerWriteRepository
{
    public CourseQuizAnswerWriteRepository(IdentityContext context) : base(context)
    {
    }
}