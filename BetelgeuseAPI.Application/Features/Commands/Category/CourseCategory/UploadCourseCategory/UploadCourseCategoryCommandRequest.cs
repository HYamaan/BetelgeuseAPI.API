using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.CourseCategory.UploadCourseCategory;

public class UploadCourseCategoryCommandRequest : IRequest<UploadCourseCategoryCommandResponse>
{
    public string CategoryName { get; set; }
    public bool Published { get; set; }
    public Guid? ParentCategoryID { get; set; }
}