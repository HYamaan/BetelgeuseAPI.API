
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileImage
{
    public class UploadProfileImageCommandRequest : IRequest<UploadProfileImageCommandResponse>
    {
        public IFormFile? profileImage { get; set; }
    }
}
