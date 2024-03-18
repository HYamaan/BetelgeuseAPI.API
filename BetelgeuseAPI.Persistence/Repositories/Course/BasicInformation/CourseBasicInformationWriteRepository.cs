using BetelgeuseAPI.Application.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.BasicInformation;

public class CourseBasicInformationWriteRepository:WriteRepository<IdentityContext,CourseBasicInformation>, ICourseBasicInformationWriteRepository
{
    public CourseBasicInformationWriteRepository(IdentityContext context) : base(context)
    {
    }
}