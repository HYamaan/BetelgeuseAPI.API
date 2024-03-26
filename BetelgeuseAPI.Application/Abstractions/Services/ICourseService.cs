using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.CourseQuestion.UpdateCourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.DeleteCourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.UploadCourseQuiz;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.UpdateCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.Delete.DeleteCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CoursePricing;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseQuizes;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSections;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSource;
using BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;
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
    Task<Response<CourseQuizCommandResponse>> AddCourseQuiz(CourseQuizCommandRequest model);
    Task<Response<CourseQuestionCommandResponse>> AddCourseQuestion(CourseQuestionCommandRequest model);

    Task<Response<UpdateCourseSectionCommandResponse>> UpdateCourseSection(UpdateCourseSectionCommandRequest model);
    Task<Response<UploadCourseQuizCommandResponse>> UploadCourseQuiz(UploadCourseQuizCommandRequest model);
    Task<Response<UpdateCourseQuestionCommandResponse>> UpdateCourseQuestion(UpdateCourseQuestionCommandRequest model);

    Task<Response<GetBasicInformationCommandResponse>> GetCourseBasicInformation(GetBasicInformationCommandRequest model);

    Task<Response<DeleteCourseSectionCommandResponse>> DeleteCourseSection(DeleteCourseSectionCommandRequest model);
    Task<Response<DeleteCourseQuestionCommandResponse>> DeleteCourseQuestion(DeleteCourseQuestionCommandRequest model);
}