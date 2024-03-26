using BetelgeuseAPI.Application.Repositories.Course.CourseExtraInformation;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.CourseExtraInformation;

public class CourseExtraInformationWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.CourseExtraInformation>, ICourseExtraInformationWriteRepository
{
    public CourseExtraInformationWriteRepository(IdentityContext context) : base(context)
    {
    }
}