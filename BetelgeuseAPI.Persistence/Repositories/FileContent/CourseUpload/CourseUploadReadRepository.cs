using BetelgeuseAPI.Application.Repositories.FileContent.CourseUpload;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseUpload;

public class CourseUploadReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.Content.CourseUpload>, ICourseUploadReadRepository
{
    public CourseUploadReadRepository(IdentityContext context) : base(context)
    {
    }
}