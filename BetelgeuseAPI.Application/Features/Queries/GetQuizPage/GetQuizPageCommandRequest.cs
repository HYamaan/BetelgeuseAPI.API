using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.GetQuizPage;

public class GetQuizPageCommandRequest : IRequest<GetQuizPageCommandResponse>
{
    public Guid QuizId { get; set; }
}