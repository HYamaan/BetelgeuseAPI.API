using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.FAQSection.GetRequirements;

public class GetRequirementsQueryHandler:IRequestHandler<GetRequirementsQueryRequest,GetRequirementsQueryResponse>
{
    private readonly ICourseService _courseService;

    public GetRequirementsQueryHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetRequirementsQueryResponse> Handle(GetRequirementsQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.GetRequirements(request);
        return new GetRequirementsQueryResponse()
        {
            Data = result.Data.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}