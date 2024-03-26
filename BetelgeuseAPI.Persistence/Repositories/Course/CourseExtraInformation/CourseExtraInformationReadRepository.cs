using BetelgeuseAPI.Application.Repositories.Course.CourseExtraInformation;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseExtraInformation;

public class CourseExtraInformationReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.CourseExtraInformation>, ICourseExtraInformationReadRepository
{
    public CourseExtraInformationReadRepository(IdentityContext context) : base(context)
    {
    }
}