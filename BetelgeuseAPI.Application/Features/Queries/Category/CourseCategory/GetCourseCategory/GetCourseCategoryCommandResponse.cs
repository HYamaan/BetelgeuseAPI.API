using BetelgeuseAPI.Application.DTOs.Response.Category;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.Category.CourseCategory.GetCourseCategory;

public class GetCourseCategoryCommandResponse:ResponseMessageAndSucceeded
{
    public List<GetCategories> Data { get; set; }
}