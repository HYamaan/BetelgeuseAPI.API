using BetelgeuseAPI.Application.Features.Commands.Course.BasicInformation;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface ICourseService
{
    Task<Response<BasicInformationCommandResponse>> BasicInformation(BasicInformationCommandRequest model);
}