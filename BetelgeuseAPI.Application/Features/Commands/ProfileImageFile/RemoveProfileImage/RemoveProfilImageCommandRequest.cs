using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.RemoveProfileImage;

public class RemoveProfilImageCommandRequest:IRequest<RemoveProfilPhotoCommandResponse>
{
    public required string Id { get; set; }
}