using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileImage;
using BetelgeuseAPI.Application.Repositories.User;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfilePhoto
{
    public class UploadProfilPhotoCommandHandler : IRequestHandler<UploadProfilPhotoCommandRequest, UploadProfilPhotoCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly IUserProfileImageFileWriteRepository _profileImageFileWriteRepository;
        readonly IUserReadRepository _userReadRepository;

        public UploadProfilPhotoCommandHandler(IStorageService storageService, IUserProfileImageFileWriteRepository profileImageFileWriteRepository, IUserReadRepository userReadRepository)
        {
            _storageService = storageService;
            _profileImageFileWriteRepository = profileImageFileWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<UploadProfilPhotoCommandResponse> Handle(UploadProfilPhotoCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.Id == null)
                    return new UploadProfilPhotoCommandResponse();
            
            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", request.File);
            User user = await _userReadRepository.GetByIdAsync(request.Id);

            var userProfileImage = new UserProfileImage()
            {
                FileName = fileName,
                Path = pathOrContainerName,
                Storage = _storageService.StorageName,
                User = user
            };

            await _profileImageFileWriteRepository.AddAsync(userProfileImage);
            await _profileImageFileWriteRepository.SaveAsync();
            return new UploadProfilPhotoCommandResponse();
        }
    }
}
