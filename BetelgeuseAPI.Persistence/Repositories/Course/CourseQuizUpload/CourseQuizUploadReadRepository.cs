using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuizUpload;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseQuizUpload;

public class CourseQuizUploadReadRepository : ReadRepository<IdentityContext,Domain.Entities.Course.Content.Quiz.CourseQuizUpload>, ICourseQuizUploadReadRepository
{
    public CourseQuizUploadReadRepository(IdentityContext context) : base(context)
    {
    }
}