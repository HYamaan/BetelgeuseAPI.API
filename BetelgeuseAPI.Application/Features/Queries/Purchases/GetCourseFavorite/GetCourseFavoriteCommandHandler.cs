using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Purchases.GetCourseFavorite;

public class GetCourseFavoriteCommandHandler:IRequestHandler<GetCourseFavoriteCommandRequest, GetCourseFavoriteCommandResponse>
{
    private readonly IPurchaseService _purchaseService;

    public GetCourseFavoriteCommandHandler(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    public async Task<GetCourseFavoriteCommandResponse> Handle(GetCourseFavoriteCommandRequest request, CancellationToken cancellationToken)
    {
       var result = await _purchaseService.GetCourseFavorite();
       return new GetCourseFavoriteCommandResponse()
       {
           Data = result.Data?.Data,
           Succeeded = result.Succeeded,
           Message = result.Message,
       };
    }
}