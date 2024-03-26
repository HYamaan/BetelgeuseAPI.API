using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetExtraInformation;

public class GetExtraInformationCommandRequest:IRequest<GetExtraInformationCommandResponse>
{
    public Guid CourseId { get; set; }
}