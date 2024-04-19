using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.GetQuizPage;

public class GetQuizPageCommandResponse:ResponseMessageAndSucceeded
{
    public ContentQuizResponseDto Data { get; set; }
}