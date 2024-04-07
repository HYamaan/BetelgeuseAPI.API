using BetelgeuseAPI.Domain.Common;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.GetCourseDetailPage;

public class GetCourseDetailPageCommandResponse:ResponseMessageAndSucceeded
{
    public DTOs.Response.Course.CourseDetail.GetCourseDetailPage Data { get; set; }
}