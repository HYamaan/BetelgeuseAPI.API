using BetelgeuseAPI.Application.Repositories.User;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.RemoveProfileImage;

public class RemoveProfilImageCommandHandler : IRequestHandler<RemoveProfilImageCommandRequest, RemoveProfilPhotoCommandResponse>
{
    private readonly IUserProfileImageFileReadRepository _userProfileImageFileReadRepository;
    private readonly IUserProfileImageFileWriteRepository _userProfileImageFileWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;
 
    public RemoveProfilImageCommandHandler(IUserProfileImageFileReadRepository userProfileImageFileReadRepository, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IUserProfileImageFileWriteRepository userProfileImageFileWriteRepository)
    {
        _userProfileImageFileReadRepository = userProfileImageFileReadRepository;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _userProfileImageFileWriteRepository = userProfileImageFileWriteRepository;
    }

    public async Task<RemoveProfilPhotoCommandResponse> Handle(RemoveProfilImageCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userReadRepository.GetByIdAsync(request.Id);
        await _userProfileImageFileWriteRepository.RemoveAsync(user.UserProfileImageId.ToString()!);
        await _userProfileImageFileWriteRepository.SaveAsync();
        return new RemoveProfilPhotoCommandResponse();
    }
}