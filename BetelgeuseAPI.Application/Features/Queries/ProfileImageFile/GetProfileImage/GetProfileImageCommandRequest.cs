using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;

public class GetProfileImageCommandRequest : IRequest<GetProfilImageCommandResponse>
{
    public required string Id { get; set; }

}