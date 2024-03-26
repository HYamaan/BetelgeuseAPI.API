using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;

public class GetBasicInformationCommandRequest:IRequest<GetBasicInformationCommandResponse>
{
    public Guid CourseId { get; set; }
}