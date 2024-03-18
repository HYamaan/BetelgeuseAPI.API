using BetelgeuseAPI.Application.Features.Commands.Course.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.CoursePricing;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface ICourseService
{
    Task<Response<BasicInformationCommandResponse>> AddCourseBasicInformation(BasicInformationCommandRequest model);
    Task<Response<CourseExtraInformationCommandResponse>> AddCourseExtraInformation(CourseExtraInformationCommandRequest model);
    Task<Response<CoursePricingCommandResponse>> AddCoursePricing(CoursePricingCommandRequest model);
}