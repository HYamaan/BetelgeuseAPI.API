using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CoursePricing;

public class CoursePricingCommandHandler:IRequestHandler<CoursePricingCommandRequest, CoursePricingCommandResponse>
{
    private readonly ICourseService _courseService;

    public CoursePricingCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<CoursePricingCommandResponse> Handle(CoursePricingCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.AddCoursePricing(request);

        return new CoursePricingCommandResponse()
        {
               Succeeded = result.Succeeded,
               Message = result.Message
          };
    }
}