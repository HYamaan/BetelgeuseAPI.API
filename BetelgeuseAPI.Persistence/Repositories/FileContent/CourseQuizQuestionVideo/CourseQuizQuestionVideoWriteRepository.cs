using BetelgeuseAPI.Application.Repositories.FileContent.CourseQuizQuestionVideo;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseQuizQuestionVideo;

public class CourseQuizQuestionVideoWriteRepository:WriteRepository<IdentityContext,Domain.Entities.File.Quiz.CourseQuizQuestionVideo>,ICourseQuizQuestionVideoWriteRepository
{
    public CourseQuizQuestionVideoWriteRepository(IdentityContext context) : base(context)
    {
    }
}