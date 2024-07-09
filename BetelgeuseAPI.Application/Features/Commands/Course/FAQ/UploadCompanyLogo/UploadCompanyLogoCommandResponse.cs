using BetelgeuseAPI.Application.DTOs.Response.Course.Faq;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadCompanyLogo;

public class UploadCompanyLogoCommandResponse:ResponseMessageAndSucceeded
{
    public CourseLogoResponseDto Data { get; set; }
}