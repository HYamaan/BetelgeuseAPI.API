using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.DeleteNewCoursePricing;

public class DeleteNewCoursePricingCommandHandler: IRequestHandler<DeleteNewCoursePricingCommandRequest, DeleteNewCoursePricingCommandResponse>
{
    private readonly ICourseService _courseService;

    public DeleteNewCoursePricingCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<DeleteNewCoursePricingCommandResponse> Handle(DeleteNewCoursePricingCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.PricingId == Guid.Empty)
        {
            return new DeleteNewCoursePricingCommandResponse()
            {
                Succeeded = false,
                Message = "Invalid Pricing Id"
            };
        }
        var result = await _courseService.DeleteNewCoursePricing(request);
        if (result.Succeeded)
        {
            return new DeleteNewCoursePricingCommandResponse()
            {
                Succeeded = true,
                Message = "Course Pricing Deleted Successfully"
            };
        }
        return new DeleteNewCoursePricingCommandResponse()
        {
            Succeeded = false,
            Message = "Invalid Pricing Id"
        };
    }
}