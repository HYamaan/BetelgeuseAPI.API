using BetelgeuseAPI.Application.Repositories.Course.CourseSource;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseSource;

public class CourseSourceWriteRepository : WriteRepository<IdentityContext, Domain.Entities.Course.Content.CourseSource>, ICourseSourceWriteRepository
{
    public CourseSourceWriteRepository(IdentityContext context) : base(context)
    {
    }
}
