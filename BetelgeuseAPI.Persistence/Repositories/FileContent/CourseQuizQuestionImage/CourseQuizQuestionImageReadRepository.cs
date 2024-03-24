using BetelgeuseAPI.Application.Repositories.FileContent.CourseQuizQuestionImage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseQuizQuestionImage;

public class CourseQuizQuestionImageReadRepository:ReadRepository<IdentityContext,Domain.Entities.File.Quiz.CourseQuizQuestionImage>, ICourseQuizQuestionImageReadRepository
{
    public CourseQuizQuestionImageReadRepository(IdentityContext context) : base(context)
    {
    }
}