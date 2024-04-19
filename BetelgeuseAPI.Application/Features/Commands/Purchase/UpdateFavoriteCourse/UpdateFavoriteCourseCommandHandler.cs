using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Purchase.UpdateFavoriteCourse;

public class UpdateFavoriteCourseCommandHandler: IRequestHandler<UpdateFavoriteCourseCommandRequest, UpdateFavoriteCourseCommandResponse>
{
    private readonly IPurchaseService _purchaseService;

    public UpdateFavoriteCourseCommandHandler(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    public async Task<UpdateFavoriteCourseCommandResponse> Handle(UpdateFavoriteCourseCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _purchaseService.UpdateFavoriteCourse(request);
        return new UpdateFavoriteCourseCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}