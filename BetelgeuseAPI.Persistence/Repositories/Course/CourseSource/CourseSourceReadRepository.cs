using BetelgeuseAPI.Application.Repositories.Course.CourseSource;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseSource;

public class CourseSourceReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.Content.CourseSource>, ICourseSourceReadRepository
{
    public CourseSourceReadRepository(IdentityContext context) : base(context)
    {
    }
}