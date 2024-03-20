using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.EBookCategory.UploadEBookCategory;

public class UploadEBookCategoryCommandRequest : IRequest<UploadEBookCategoryCommandResponse>
{
    public string CategoryName { get; set; }
    public bool Published { get; set; }
    public Guid? ParentCategoryID { get; set; }
}