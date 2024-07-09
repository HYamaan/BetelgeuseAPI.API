using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseSections;

public class CourseSectionsCommandHandler : IRequestHandler<CourseSectionsCommandRequest, CourseSectionsCommandResponse>
{
    private readonly ICourseService _courseService;

    public CourseSectionsCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<CourseSectionsCommandResponse> Handle(CourseSectionsCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.AddCourseSections(request);

        return new CourseSectionsCommandResponse()
        {
            Id = result.Data.Id,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}