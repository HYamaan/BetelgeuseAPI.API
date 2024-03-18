using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.BlogCategory.UploadBlogCategory;

public class UploadBlogCategoryCommandRequest:IRequest<UploadBlogCategoryCommandResponse>
{
    public string CategoryName { get; set; }
    public bool Published { get; set; }
    public Guid? ParentCategoryID { get; set; }
}