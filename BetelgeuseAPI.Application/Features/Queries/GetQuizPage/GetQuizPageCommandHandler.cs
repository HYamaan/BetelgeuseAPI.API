using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.GetQuizPage;

public class GetQuizPageCommandHandler: IRequestHandler<GetQuizPageCommandRequest, GetQuizPageCommandResponse>
{
    private readonly ICourseService _courseService;

    public GetQuizPageCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetQuizPageCommandResponse> Handle(GetQuizPageCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _courseService.GetQuizPage(request);

        return new GetQuizPageCommandResponse()
        {
            Data = result.Data?.Data,
            Succeeded = result.Succeeded,
            Message = result.Message
        };
    }
}