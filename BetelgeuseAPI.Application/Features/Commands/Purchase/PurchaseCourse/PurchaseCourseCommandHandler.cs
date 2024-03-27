using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Purchase.PurchaseCourse;

public class PurchaseCourseCommandHandler:IRequestHandler<PurchaseCourseCommandRequest, PurchaseCourseCommandResponse>
{
    private readonly IPurchaseService _purchaseService;

    public PurchaseCourseCommandHandler(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    public async Task<PurchaseCourseCommandResponse> Handle(PurchaseCourseCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _purchaseService.PurchaseCourse(request);

        return new PurchaseCourseCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}