using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetQuizAndCertification;

public class GetQuizAndCertificationCommandRequest:IRequest<GetQuizAndCertificationCommandResponse>
{
    public Guid CourseId { get; set; }
}