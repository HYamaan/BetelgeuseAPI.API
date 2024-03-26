using BetelgeuseAPI.Application.Repositories.Course.CourseQuizUpload;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseQuizUpload;

public class CourseQuizUploadWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.Content.Quiz.CourseQuizUpload>, ICourseQuizUploadWriteRepository
{
    public CourseQuizUploadWriteRepository(IdentityContext context) : base(context)
    {
    }
}