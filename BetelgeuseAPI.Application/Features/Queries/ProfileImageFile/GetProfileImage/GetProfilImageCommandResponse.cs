namespace BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;

public class GetProfilImageCommandResponse
{
    public string? Path { get; set; }
    public string? FileName { get; set; }
    public Guid? GuidId { get; set; }
}