using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetPricing;

public class GetPricingCommandHandler:IRequestHandler<GetPricingCommandRequest,GetPricingCommandResponse>
{
    private readonly ICourseService _courseService;

    public GetPricingCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetPricingCommandResponse> Handle(GetPricingCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _courseService.GetPricing(request);

       var response = new GetPricingCommandResponse()
       {
           IsFree = result.Data.IsFree,
           Price = result.Data.Price,
           PricingPlan = result.Data?.PricingPlan,
              Message = result.Message,
              Succeeded = result.Succeeded
         };
         return response;
  
    }
}