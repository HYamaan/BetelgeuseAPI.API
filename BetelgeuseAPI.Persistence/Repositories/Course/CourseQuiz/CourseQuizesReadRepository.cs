using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuiz;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseQuiz;

public class CourseQuizesReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.Content.Quiz.CourseQuiz>,ICourseQuizesReadRepository
{
    public CourseQuizesReadRepository(IdentityContext context) : base(context)
    {
    }
}