using BetelgeuseAPI.Application.Repositories.Course.CourseQuiz;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseQuiz;

public class CourseQuizesWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.Content.Quiz.CourseQuiz>,ICourseQuizesWriteRepository
{
    public CourseQuizesWriteRepository(IdentityContext context) : base(context)
    {
    }
}