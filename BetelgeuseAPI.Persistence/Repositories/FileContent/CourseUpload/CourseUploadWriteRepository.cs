using BetelgeuseAPI.Application.Repositories.FileContent.CourseUpload;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.CourseUpload;

public class CourseUploadWriteRepository : WriteRepository<IdentityContext, Domain.Entities.Course.Content.CourseUpload>, ICourseUploadWriteRepository
{
    public CourseUploadWriteRepository(IdentityContext context) : base(context)
    {
    }
}