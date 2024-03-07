using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;

public class GetProfileImageCommandResponse:ResponseMessageAndSucceeded
{
    public string? Path { get; set; }
    public string? FileName { get; set; }
    public Guid? GuidId { get; set; }
}