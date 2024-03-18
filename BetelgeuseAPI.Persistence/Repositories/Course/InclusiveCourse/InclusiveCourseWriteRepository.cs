using BetelgeuseAPI.Application.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.InclusiveCourse;

public class InclusiveCourseWriteRepository : WriteRepository<IdentityContext, Domain.Entities.Course.InclusiveCourse>,
    IInclusiveCourseWriteRepository
{
    public InclusiveCourseWriteRepository(IdentityContext context) : base(context)
    {
    }
}