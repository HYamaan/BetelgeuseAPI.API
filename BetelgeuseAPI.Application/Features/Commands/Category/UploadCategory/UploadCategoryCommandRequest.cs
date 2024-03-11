using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Category.UploadCategory;

public class UploadCategoryCommandRequest : IRequest<UploadCategoryCommandResponse>
{
    public string CategoryName { get; set; }
    public bool Published { get; set; }
    public Guid? ParentCategoryID { get; set; }

}