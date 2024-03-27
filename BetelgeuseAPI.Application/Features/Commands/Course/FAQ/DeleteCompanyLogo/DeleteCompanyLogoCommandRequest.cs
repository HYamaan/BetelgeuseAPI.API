using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteComponyLogo;

public class DeleteCompanyLogoCommandRequest:IRequest<DeleteCompanyLogoCommandResponse>
{
    public required Guid Id { get; set; }
    public required Guid CourseId { get; set; }
}