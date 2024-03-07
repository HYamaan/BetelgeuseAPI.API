using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileBackgroundImage;

public class GetProfileBackgroundImageCommandResponse:ResponseMessageAndSucceeded
{
    public string? Path { get; set; }
    public string? FileName { get; set; }
    public Guid? GuidId { get; set; }
}