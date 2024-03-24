using BetelgeuseAPI.Application.Repositories.FileContent.CourseQuizQuestionImage;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseQuizQuestionImage;

public class CourseQuizQuestionImageWriteRepository:WriteRepository<IdentityContext,Domain.Entities.File.Quiz.CourseQuizQuestionImage>, ICourseQuizQuestionImageWriteRepository
{
    public CourseQuizQuestionImageWriteRepository(IdentityContext context) : base(context)
    {
    }
}