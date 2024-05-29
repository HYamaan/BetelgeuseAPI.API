using BetelgeuseAPI.Application.DTOs.Request.Course.LearningPage;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetCourseLearningPage;

public class GetCourseLearningPageCommandResponse:ResponseMessageAndSucceeded
{
    public List<LearningPageSectionResponseDto> Data { get; set; }
}