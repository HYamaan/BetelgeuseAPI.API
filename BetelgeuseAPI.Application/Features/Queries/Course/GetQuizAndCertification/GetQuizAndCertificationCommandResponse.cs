using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetQuizAndCertification;

public class GetQuizAndCertificationCommandResponse:ResponseMessageAndSucceeded
{
    public List<ContentQuizResponseDto> Data { get; set; }
}