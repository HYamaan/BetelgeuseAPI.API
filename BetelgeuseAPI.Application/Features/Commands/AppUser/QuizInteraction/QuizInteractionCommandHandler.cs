using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.AppUser.QuizInteraction;

public class QuizInteractionCommandHandler:IRequestHandler<QuizInteractionCommandRequest, QuizInteractionCommandResponse>
{
    private readonly IUserService _userService;

    public QuizInteractionCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<QuizInteractionCommandResponse> Handle(QuizInteractionCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _userService.UpdateQuizInteraction(request);

        return new QuizInteractionCommandResponse()
        {
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}