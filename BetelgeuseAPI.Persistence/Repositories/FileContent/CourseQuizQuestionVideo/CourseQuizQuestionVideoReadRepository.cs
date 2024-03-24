using BetelgeuseAPI.Application.Repositories.FileContent.CourseQuizQuestionVideo;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseQuizQuestionVideo;

public class CourseQuizQuestionVideoReadRepository:ReadRepository<IdentityContext,Domain.Entities.File.Quiz.CourseQuizQuestionVideo>, ICourseQuizQuestionVideoReadRepository
{
    public CourseQuizQuestionVideoReadRepository(IdentityContext context) : base(context)
    {
    }
}