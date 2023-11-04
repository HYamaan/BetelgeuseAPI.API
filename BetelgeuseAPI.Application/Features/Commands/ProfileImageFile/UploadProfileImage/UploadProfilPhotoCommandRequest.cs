
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileImage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfilePhoto
{
    public class UploadProfilPhotoCommandRequest : IRequest<UploadProfilPhotoCommandResponse>
    {
        public IFormFile? File { get; set; }
        public string? Id { get; set; }
    }
}
