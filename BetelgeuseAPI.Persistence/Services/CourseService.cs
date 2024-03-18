using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Features.Commands.Course.BasicInformation;
using BetelgeuseAPI.Application.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Persistence.Services;

public class CourseService:ICourseService
{
    private readonly ICourseBasicInformationReadRepository _courseBasicInformationRead;
    private readonly ICourseBasicInformationWriteRepository _courseBasicInformationWrite;

    private readonly ICourseThumbnailReadRepository _courseThumbnailRead;
    private readonly ICourseThumbnailWriteRepository _courseThumbnailWrite;

    public CourseService(ICourseBasicInformationReadRepository courseBasicInformationRead, ICourseBasicInformationWriteRepository courseBasicInformationWrite)
    {
        _courseBasicInformationRead = courseBasicInformationRead;
        _courseBasicInformationWrite = courseBasicInformationWrite;
    }

    public Task<Response<BasicInformationCommandResponse>> BasicInformation(BasicInformationCommandRequest model)
    {

        throw new NotImplementedException();
    }
}