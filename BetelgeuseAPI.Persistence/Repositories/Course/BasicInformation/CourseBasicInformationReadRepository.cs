using BetelgeuseAPI.Application.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.BasicInformation;

public class CourseBasicInformationReadRepository:ReadRepository<IdentityContext,CourseBasicInformation>, ICourseBasicInformationReadRepository
{
    public CourseBasicInformationReadRepository(IdentityContext context) : base(context)
    {
    }
}