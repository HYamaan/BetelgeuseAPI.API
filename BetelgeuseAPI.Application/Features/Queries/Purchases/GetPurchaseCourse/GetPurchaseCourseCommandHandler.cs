using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Purchases.GetPurchaseCourse;

public class GetPurchaseCourseCommandHandler:IRequestHandler<GetPurchaseCourseCommandRequest, GetPurchaseCourseCommandResponse>
{
    private readonly IPurchaseService _purchaseService;

    public GetPurchaseCourseCommandHandler(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    public async Task<GetPurchaseCourseCommandResponse> Handle(GetPurchaseCourseCommandRequest request, CancellationToken cancellationToken)
    {
        var result  = await _purchaseService.GetPurchaseCourse();
        return new GetPurchaseCourseCommandResponse()
        {
            Data = result.Data?.Data,
            Succeeded = result.Succeeded,
            Message = result.Message,
        };
    }
}