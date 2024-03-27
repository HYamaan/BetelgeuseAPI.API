using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetQuizAndCertification;

public class GetQuizAndCertificationCommandHandler:IRequestHandler<GetQuizAndCertificationCommandRequest, GetQuizAndCertificationCommandResponse>
{
    private readonly ICourseService _courseService;

    public GetQuizAndCertificationCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetQuizAndCertificationCommandResponse> Handle(GetQuizAndCertificationCommandRequest request, CancellationToken cancellationToken)
    {
      var result = await _courseService.GetQuizAndCertification(request);
      return new GetQuizAndCertificationCommandResponse()
      {
            Data = result.Data?.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}