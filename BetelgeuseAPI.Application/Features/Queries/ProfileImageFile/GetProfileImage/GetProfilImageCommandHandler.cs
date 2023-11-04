using BetelgeuseAPI.Application.Repositories.User;
using BetelgeuseAPI.Application.Repositories.UserProfileImageFile;
using BetelgeuseAPI.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;

public class GetProfilImageCommandHandler : IRequestHandler<GetProfileImageCommandRequest, GetProfilImageCommandResponse>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserProfileImageFileReadRepository _userProfileImageFileReadRepository;
    private readonly IConfiguration _configuration;

    public GetProfilImageCommandHandler(IUserReadRepository userReadRepository, IConfiguration configuration, IUserProfileImageFileReadRepository userProfileImageFileReadRepository)
    {
        _userReadRepository = userReadRepository;
        _configuration = configuration;
        _userProfileImageFileReadRepository = userProfileImageFileReadRepository;
    }

    public async Task<GetProfilImageCommandResponse> Handle(GetProfileImageCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userReadRepository.GetByIdAsync(request.Id);
        UserProfileImage userProfileImage = await _userProfileImageFileReadRepository.GetByIdAsync(user.UserProfileImageId.ToString()!);
        GetProfilImageCommandResponse getProfilImageCommandResponse = new GetProfilImageCommandResponse()
        {
            Path = $"{_configuration["BaseStorageUrl"]}/{userProfileImage.Path}",
            FileName = userProfileImage.FileName,
            GuidId = userProfileImage.Id
        };

        return getProfilImageCommandResponse;

    }
}