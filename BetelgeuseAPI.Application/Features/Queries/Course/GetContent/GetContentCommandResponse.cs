using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetContent;

public class GetContentCommandResponse:ResponseMessageAndSucceeded
{
    public List<ContentSectionResponseDto> Data { get; set; }
}