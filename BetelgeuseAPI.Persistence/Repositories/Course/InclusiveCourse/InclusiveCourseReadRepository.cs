using BetelgeuseAPI.Application.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.InclusiveCourse;

public class InclusiveCourseReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.InclusiveCourse>, IInclusiveCourseReadRepository
{
    public InclusiveCourseReadRepository(IdentityContext context) : base(context)
    {
    }
}