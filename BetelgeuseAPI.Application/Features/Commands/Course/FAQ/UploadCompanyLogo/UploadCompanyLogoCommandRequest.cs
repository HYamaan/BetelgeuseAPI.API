using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadCompanyLogo;

public class UploadCompanyLogoCommandRequest:IRequest<UploadCompanyLogoCommandResponse>
{
    public int Order { get; set; }
    public Guid CourseId { get; set; }
    public IFormFile Image { get; set; }

}