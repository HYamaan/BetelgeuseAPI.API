using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetContent;

public class GetContentCommandRequest:IRequest<GetContentCommandResponse>
{
    public Guid CourseId { get; set; }
}