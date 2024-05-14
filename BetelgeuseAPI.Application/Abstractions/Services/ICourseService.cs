using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseQuiz;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseSections;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseSource;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseTypeOrder;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.CourseQuestion.UpdateCourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.DeleteCourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.UploadCourseQuiz;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.DeleteCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.UpdateCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteComponyLogo;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteFaq;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteFaqLearningMaterial;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteRequirements;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.FaqTypeOrder;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadCompanyLogo;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadFaq;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadLearningMaterial;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadRequirements;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CoursePricing;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.DeleteNewCoursePricing;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.MessageToReview;
using BetelgeuseAPI.Application.Features.Queries.Course.CoursesPage;
using BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;
using BetelgeuseAPI.Application.Features.Queries.Course.GetContent;
using BetelgeuseAPI.Application.Features.Queries.Course.GetCourseDetailPage;
using BetelgeuseAPI.Application.Features.Queries.Course.GetCourseLearningPage;
using BetelgeuseAPI.Application.Features.Queries.Course.GetExtraInformation;
using BetelgeuseAPI.Application.Features.Queries.Course.GetPricing;
using BetelgeuseAPI.Application.Features.Queries.Course.GetQuizAndCertification;
using BetelgeuseAPI.Application.Features.Queries.GetQuizPage;
using BetelgeuseAPI.Domain.Common;

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
    Task<Response<MessageToReviewCommandResponse>> AddMessageToReview (MessageToReviewCommandRequest model);

    Task<Response<UpdateCourseSectionCommandResponse>> UpdateCourseSection(UpdateCourseSectionCommandRequest model);
    Task<Response<UploadCourseQuizCommandResponse>> UploadCourseQuiz(UploadCourseQuizCommandRequest model);
    Task<Response<UpdateCourseQuestionCommandResponse>> UpdateCourseQuestion(UpdateCourseQuestionCommandRequest model);
    Task<Response<CourseTypeOrderCommandResponse>> UpdateCourseTypeOrder(CourseTypeOrderCommandRequest model);
    Task<Response<FaqTypeOrderCommandResponse>> UpdateFaqTypeOrder(FaqTypeOrderCommandRequest model);

    Task<Response<UploadFaqCommandResponse>> UploadFaq(UploadFaqCommandRequest model);
    Task<Response<UploadLearningMaterialCommandResponse>> UploadLearningMaterial(UploadLearningMaterialCommandRequest model);
    Task<Response<UploadCompanyLogoCommandResponse>> UploadCompanyLogo(UploadCompanyLogoCommandRequest model);
    Task<Response<UploadRequirementsCommandResponse>> UploadRequirements(UploadRequirementsCommandRequest model);

    Task<Response<GetBasicInformationCommandResponse>> GetCourseBasicInformation(GetBasicInformationCommandRequest model);
    Task<Response<GetExtraInformationCommandResponse>> GetExtraInformation(GetExtraInformationCommandRequest model);
    Task<Response<GetPricingCommandResponse>> GetPricing(GetPricingCommandRequest model);
    Task<Response<GetContentCommandResponse>> GetContent(GetContentCommandRequest model);
    Task<Response<GetQuizAndCertificationCommandResponse>> GetQuizAndCertification(GetQuizAndCertificationCommandRequest model);
    Task<Response<GetCourseLearningPageCommandResponse>> GetCourseLearningPage(GetCourseLearningPageCommandRequest model);
    Task<Response<GetCoursesPageCommandResponse>> GetCoursesPage(GetCoursesPageCommandRequest model);
    Task<Response<GetCourseDetailPageCommandResponse>> GetCourseDetailPage(GetCourseDetailPageCommandRequest model);
    Task<Response<GetQuizPageCommandResponse>> GetQuizPage(GetQuizPageCommandRequest model);
    
    Task<Response<DeleteNewCoursePricingCommandResponse>> DeleteNewCoursePricing(DeleteNewCoursePricingCommandRequest model);
    Task<Response<DeleteCourseSectionCommandResponse>> DeleteCourseSection(DeleteCourseSectionCommandRequest model);
    Task<Response<DeleteCourseQuestionCommandResponse>> DeleteCourseQuestion(DeleteCourseQuestionCommandRequest model);
    Task<Response<DeleteFaqCommandResponse>> DeleteFaqOption(DeleteFaqCommandRequest model);
    Task<Response<DeleteRequirementsCommandResponse>> DeleteRequirements(DeleteRequirementsCommandRequest model);
    Task<Response<DeleteCompanyLogoCommandResponse>> DeleteCompanyLogo(DeleteCompanyLogoCommandRequest model);
    Task<Response<DeleteFaqLearningMaterialCommandResponse>> DeleteFaqLearningMaterial(DeleteFaqLearningMaterialCommandRequest model);



}