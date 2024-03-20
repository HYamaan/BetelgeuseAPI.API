using BetelgeuseAPI.Application.Features.Commands.Course.Delete.DeleteCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CoursePricing;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSections;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSource;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course.Content;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface ICourseService
{
    Task<Response<BasicInformationCommandResponse>> AddCourseBasicInformation(BasicInformationCommandRequest model);
    Task<Response<CourseExtraInformationCommandResponse>> AddCourseExtraInformation(CourseExtraInformationCommandRequest model);
    Task<Response<CoursePricingCommandResponse>> AddCoursePricing(CoursePricingCommandRequest model);
    Task<Response<CourseSectionsCommandResponse>> AddCourseSections(CourseSectionsCommandRequest model);
    Task<Response<CourseSourceCommandResponse>> AddCourseSource(CourseSourceCommandRequest model);




    Task<Response<DeleteCourseSectionCommandResponse>> DeleteCourseSection(DeleteCourseSectionCommandRequest model);
}