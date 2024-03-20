using MediatR;using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileBackgroundImage
{
    public class UploadProfileBackgroundImageCommandRequest : IRequest<UploadProfileBackgroundImageCommandResponse>
    {
        public IFormFile? profileBackgroundImage { get; set; }
    }
}
