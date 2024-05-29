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
using BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseFaq;
using BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetCourseLearningMaterial;
using BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;
using BetelgeuseAPI.Application.Features.Queries.Course.GetContent;
using BetelgeuseAPI.Application.Features.Queries.Course.GetCourseDetailPage;
using BetelgeuseAPI.Application.Features.Queries.Course.GetCourseLearningPage;
using BetelgeuseAPI.Application.Features.Queries.Course.GetExtraInformation;
using BetelgeuseAPI.Application.Features.Queries.Course.GetPricing;
using BetelgeuseAPI.Application.Features.Queries.Course.GetQuizAndCertification;
using BetelgeuseAPI.Application.Features.Queries.GetQuizPage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadBasicInformation([FromForm] BasicInformationCommandRequest model)
        {
            model.Thumbnail = Request.Form.Files[0];
            model.CoverImage = Request.Form.Files[0];
            BasicInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadExtraInformation([FromBody] CourseExtraInformationCommandRequest model)
        {
            CourseExtraInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadPricing([FromBody] CoursePricingCommandRequest model)
        {
            CoursePricingCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadSections([FromBody] CourseSectionsCommandRequest model)
        {
            CourseSectionsCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadSource([FromForm] CourseSourceCommandRequest model)
        {
            if (model.uploadFile != null)
            {
                model.uploadFile = Request.Form.Files[0];
            }
            CourseSourceCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadQuiz([FromBody] CourseQuizCommandRequest model)
        {
            CourseQuizCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadQuestion([FromForm] CourseQuestionCommandRequest model)
        {
            CourseQuestionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFaqOption([FromBody] UploadFaqCommandRequest model)
        {
            UploadFaqCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadLearningMaterial([FromBody] UploadLearningMaterialCommandRequest model)
        {
            UploadLearningMaterialCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadCompanyLogo([FromForm] UploadCompanyLogoCommandRequest model)
        {
            if (model.Image != null)
            {
                model.Image = Request.Form.Files[0];
            }
            UploadCompanyLogoCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadRequirements([FromBody] UploadRequirementsCommandRequest model)
        {
            UploadRequirementsCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadMessageToReview([FromBody] MessageToReviewCommandRequest model)
        {
            MessageToReviewCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateCourseTypeOrder([FromBody] CourseTypeOrderCommandRequest model)
        {
            CourseTypeOrderCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFaqTypeOrder([FromBody] FaqTypeOrderCommandRequest model)
        {
            FaqTypeOrderCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSection([FromBody] UpdateCourseSectionCommandRequest model)
        {
            UpdateCourseSectionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateQuiz([FromBody] UploadCourseQuizCommandRequest model)
        {
            UploadCourseQuizCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateQuestion([FromForm] UpdateCourseQuestionCommandRequest model)
        {
            UpdateCourseQuestionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }


        [Authorize(Roles = "Moderator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasicInformation([FromBody] GetBasicInformationCommandRequest model)
        {
            GetBasicInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetExtraInformation([FromBody] GetExtraInformationCommandRequest model)
        {
            GetExtraInformationCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPricing([FromQuery] GetPricingCommandRequest model)
        {
            GetPricingCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetContent([FromBody] GetContentCommandRequest model)
        {
            GetContentCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetQuizAndCertification([FromBody] GetQuizAndCertificationCommandRequest model)
        {
            GetQuizAndCertificationCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCourseLearningPage([FromBody] GetCourseLearningPageCommandRequest model)
        {
            GetCourseLearningPageCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetQuizPage([FromBody] GetQuizPageCommandRequest model)
        {
            GetQuizPageCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCoursesPage([FromBody] GetCoursesPageCommandRequest model)
        {
            GetCoursesPageCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCourseDetailPage([FromBody] GetCourseDetailPageCommandRequest model)
        {
            GetCourseDetailPageCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCourseFaqList([FromQuery] GetCourseFaqQueryRequest model)
        {
            GetCourseFaqQueryResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [Authorize(Roles = "Moderator")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCourseLearningMaterialList([FromQuery] GetCourseLearningMaterialQueryRequest model)
        {
            GetCourseLearningMaterialQueryResponse response = await _mediator.Send(model);
            return Ok(response);

        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSection([FromBody] DeleteCourseSectionCommandRequest model)
        {
           
            DeleteCourseSectionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteQuestion([FromBody] DeleteCourseQuestionCommandRequest model)
        {
            DeleteCourseQuestionCommandResponse response = await _mediator.Send(model);
            return Ok(response);

        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteFaqOption([FromBody] DeleteFaqCommandRequest model)
        {
            DeleteFaqCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteRequirements([FromBody] DeleteRequirementsCommandRequest model)
        {
            DeleteRequirementsCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCompanyLogo([FromBody] DeleteCompanyLogoCommandRequest model)
        {
            DeleteCompanyLogoCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteLearningMaterial([FromBody] DeleteFaqLearningMaterialCommandRequest model)
        {
            DeleteFaqLearningMaterialCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }

        [Authorize(Roles = "Moderator")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteNewPricing([FromQuery] DeleteNewCoursePricingCommandRequest model)
        {
            DeleteNewCoursePricingCommandResponse response = await _mediator.Send(model);
            return Ok(response);
        }


    }
}
