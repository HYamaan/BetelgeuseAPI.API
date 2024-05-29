using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Course.CoursesPage;

public class GetCoursesPageCommandResponse:ResponseMessageAndSucceeded
{
    public int CourseCount { get; set; }
    public List<GetAllCoursesPage> Data { get; set; }
}