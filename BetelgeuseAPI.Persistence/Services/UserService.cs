using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UploadAccountInformation;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using Microsoft.AspNetCore.Http;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.DeleteProfileBackgroundImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.DeleteProfileImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileBackgroundImage;
using BetelgeuseAPI.Application.Features.Commands.ProfileImageFile.UploadProfileImage;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountExperiences;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.DeleteAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.UpdateAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.DeleteAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.UpdateAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UpdateAccountAbout;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UserSkill.AddUserSkill;
using BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileBackgroundImage;
using BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountAbout;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountEducation;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountExperiences;
using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Entities.File;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileBackgroundImageFile;
using BetelgeuseAPI.Application.Repositories.FileContent.UserProfileImageFile;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountInformation;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountExperiences;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountEducation;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountAbout;
using BetelgeuseAPI.Application.Repositories.UserAccountSettings.UserAccountSkills;
using BetelgeuseAPI.Application.Abstractions.Services.Helpers;


namespace BetelgeuseAPI.Persistence.Services;
public class UserService:IUserService
{
    private readonly IServicesHelper _servicesHelper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserAccountInformationReadRepository _informationReadRepository;
    private readonly IUserAccountAboutReadRepository _aboutReadRepository;

    private readonly IUserAccountInformationWriteRepository _informationWriteRepository;
    private readonly IUserAccountExperiencesWriteRepository _experiencesWriteRepository;
    private readonly IUserAccountExperiencesReadRepository _experiencesReadRepository;
    private readonly IUserAccountEducationReadRepository _educationReadRepository;
    private readonly IUserAccountEducationWriteRepository _educationWriteRepository;
    private readonly IStorageService _storageService;
    private readonly IUserProfileImageFileWriteRepository _profileImageFileWriteRepository;
    private readonly IUserProfileImageFileReadRepository _profileImageFileReadRepository;
    private readonly IUserProfileBackgroundImageFileReadRepository _profileBackgroundImageReadRepository;
    private readonly IUserProfileBackgroundImageFileWriteRepository _profileBackgroundImageFileWriteRepository ;
    private readonly IAllUserAccountSkillReadRepository _allUserAccountSkillReadRepository;
    private readonly IUserAccountSkillsWriteRepository _userAccountSkillWriteRepository;
    private readonly IUserAccountSkillsReadRepository _userAccountSkillReadRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    private readonly IImageService<UserProfileImage, IUserProfileImageFileReadRepository, IUserProfileImageFileWriteRepository> _imageService;
    private readonly IImageService<UserProfileBackgroundImage, IUserProfileBackgroundImageFileReadRepository, IUserProfileBackgroundImageFileWriteRepository> _imageBackgroundService;

    public UserService(
        IHttpContextAccessor httpContextAccessor,
        IUserAccountInformationReadRepository informationReadRepository,
        IUserAccountAboutReadRepository aboutReadRepository,
        IUserAccountInformationWriteRepository informationWriteRepository,
        IUserAccountExperiencesWriteRepository experiencesWriteRepository,
        IUnitOfWork unitOfWork, IUserAccountExperiencesReadRepository experiencesReadRepository,
        IUserAccountEducationReadRepository educationReadRepository,
        IUserAccountEducationWriteRepository educationWriteRepository, 
        IStorageService storageService,
        IUserProfileImageFileWriteRepository profileImageFileWriteRepository,
        IUserProfileImageFileReadRepository profileImageFileReadRepository, 
        IConfiguration configuration,
        IUserProfileBackgroundImageFileWriteRepository profileBackgroundImageFileWriteRepository,
        IUserProfileBackgroundImageFileReadRepository profileBackgroundImageReadRepository, IServicesHelper servicesHelper, IAllUserAccountSkillReadRepository allUserAccountSkillReadRepository, IUserAccountSkillsReadRepository userAccountSkillReadRepository, IUserAccountSkillsWriteRepository userAccountSkillWriteRepository, IImageService<UserProfileImage, IUserProfileImageFileReadRepository, IUserProfileImageFileWriteRepository> imageService, IImageService<UserProfileBackgroundImage, IUserProfileBackgroundImageFileReadRepository, IUserProfileBackgroundImageFileWriteRepository> imageBackgroundService)
    {
        _httpContextAccessor = httpContextAccessor;
        _informationReadRepository = informationReadRepository;
        _aboutReadRepository = aboutReadRepository;
        _informationWriteRepository = informationWriteRepository;
        _experiencesWriteRepository = experiencesWriteRepository;
        _unitOfWork = unitOfWork;
        _experiencesReadRepository = experiencesReadRepository;
        _educationReadRepository = educationReadRepository;
        _educationWriteRepository = educationWriteRepository;
        _storageService = storageService;
        _profileImageFileWriteRepository = profileImageFileWriteRepository;
        _profileImageFileReadRepository = profileImageFileReadRepository;
        _configuration = configuration;
        _profileBackgroundImageFileWriteRepository = profileBackgroundImageFileWriteRepository;
        _profileBackgroundImageReadRepository = profileBackgroundImageReadRepository;
        _servicesHelper = servicesHelper;
        _allUserAccountSkillReadRepository = allUserAccountSkillReadRepository;
        _userAccountSkillReadRepository = userAccountSkillReadRepository;
        _userAccountSkillWriteRepository = userAccountSkillWriteRepository;
        _imageService = imageService;
        _imageBackgroundService = imageBackgroundService;
    }

    public async Task<Response<UpdateAccountCommandResponse>> UpdateAccountInformation(UpdateAccountCommandRequest request)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var user = await _servicesHelper.GetUserById(userId);

        var userInfo = await _informationReadRepository.GetByIdAsync(userId);
        if (userInfo != null)
        {
            userInfo.Currency = string.IsNullOrEmpty(request.Currency) ? userInfo.Currency : request.Currency;
            userInfo.Language = string.IsNullOrEmpty(request.Language) ? userInfo.Language : request.Language;
            userInfo.TimeZone = string.IsNullOrEmpty(request.TimeZone) ? userInfo.TimeZone : request.TimeZone;
            userInfo.EmailNews = request.EmailNews ?? userInfo.EmailNews;

            user.UserName = string.IsNullOrEmpty(request.Name) ? user.UserName : request.Name;
            user.PhoneNumber = string.IsNullOrEmpty(request.Phone) ? user.PhoneNumber : request.Phone;
            user.Email = string.IsNullOrEmpty(request.Email) ? user.Email : request.Email;
        }
        else
        {
            var userLanguage = _httpContextAccessor?.HttpContext?.Request.Headers["Accept-Language"].ToString();
            var userLanguageSplit = userLanguage.Split(",")[0];

            var userAccountInfo = new UserAccountInformation
            {
                AppUserId = user.Id,
                Language = userLanguageSplit, 
                TimeZone = "UTC", 
                Currency = "USD",
                EmailNews = false
            };
            await _informationWriteRepository.AddAsync(userAccountInfo);
        }
        
        await _unitOfWork.CommitIdentityAsync();
        return new Response<UpdateAccountCommandResponse>()
        {
            Succeeded = true,
            Message = "Kullanıcı bilgileri güncellendi."
        };
    }
    public async Task<Response<UpdateAccountAboutCommandResponse>> UpdateAccountAbout(UpdateAccountAboutCommandRequest request)
    {
        var userId = _servicesHelper.GetUserIdFromContext();

        var userInfo = await _aboutReadRepository.GetByIdAsync(userId);
        
            userInfo.Biography = request.Biography;
            userInfo.JobTitle = request.JobTitle;
            userInfo.AppUserId = userId;

            await _unitOfWork.CommitIdentityAsync();
        return new Response<UpdateAccountAboutCommandResponse>()
        {
            Succeeded = true,
            Message = "Kullanıcı bilgileri güncellendi."
        };
    }

    public async Task<Response<UpdateAccountEducationCommandResponse>> UpdateAccountEducation(UpdateAccountEducationCommandRequest request)
    {
        try
        {
            var findEducation = await _educationReadRepository.GetByIdAsync(request.Id);
            findEducation.Education = request.Education;
            await _unitOfWork.CommitIdentityAsync();
            return Response<UpdateAccountEducationCommandResponse>.Success("Eğitim değiştirildi.");
        }
        catch (Exception e)
        {
            return Response<UpdateAccountEducationCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<UpdateAccountExperiencesCommandResponse>> UpdateAccountExperience(UpdateAccountExperiencesCommandRequest request)
    {
        try
        {
            var findExperience = await _experiencesReadRepository.GetByIdAsync(request.Id);
            findExperience.Experiences = request.Experience;
            await _unitOfWork.CommitIdentityAsync();
            return Response<UpdateAccountExperiencesCommandResponse>.Success("Başarılı bir şekilde güncellendi.");
        }
        catch (Exception e)
        {
            return Response<UpdateAccountExperiencesCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<AddAccountExperiencesCommandResponse>> AddAccountExperiences(AddAccountExperiencesCommandRequest request)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var experiences = new UserAccountExperiences()
        {
            AppUserId = userId,
            Experiences = request.Experiences!
        };
        await _experiencesWriteRepository.AddAsync(experiences);
        await _unitOfWork.CommitIdentityAsync();
        return Response<AddAccountExperiencesCommandResponse>.Success(null,
            "The experience has been successfully added");
    }

    public async Task<Response<AddAccountEducationCommandResponse>> AddAccountEducation(AddAccountEducationCommandRequest request)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var education = new UserAccountEducation()
        {
            AppUserId = userId,
            Education = request.Education
        };
        await _educationWriteRepository.AddAsync(education);
        await _educationWriteRepository.SaveAsync();
        return Response<AddAccountEducationCommandResponse>.Success(null,
            "The experience has been successfully added");
    }

    public async Task<Response<UploadProfileImageCommandResponse>> AddProfilePhoto(UploadProfileImageCommandRequest request)
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            await _imageService.UpdateImage(request.profileImage, userId);
            return Response<UploadProfileImageCommandResponse>.Success("Resim başarılı bir şekilde yüklendi.");
        }
        catch (Exception e)
        {
            return Response<UploadProfileImageCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<UploadProfileBackgroundImageCommandResponse>> AddProfileBackgroundPhoto(UploadProfileBackgroundImageCommandRequest request)
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            await _imageBackgroundService.UpdateImage(request.profileBackgroundImage, userId);    
            return Response<UploadProfileBackgroundImageCommandResponse>.Success("Resim başarılı bir şekilde yüklendi.");
        }
        catch (Exception e)
        {
            return Response<UploadProfileBackgroundImageCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<AddUserSkillCommandResponse>> AddUserSkill(AddUserSkillCommandRequest request)
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();

            var userSkill = await _userAccountSkillReadRepository
                .GetWhere(ux => ux.AppUserId == userId && ux.AllUserSkillsId == Guid.Parse(request.Id))
                .FirstOrDefaultAsync();

            if (userSkill != null)
            {
                userSkill.IsCheck = request.isCheck;
                _userAccountSkillWriteRepository.Update(userSkill);
            }
            else
            {
                var globalSkill = await _allUserAccountSkillReadRepository.GetWhere(ux => ux.Id == Guid.Parse(request.Id)).FirstOrDefaultAsync();

                var newUserSkill = new UserSkills
                {
                    AppUserId = userId,
                    AllUserSkills = globalSkill ?? throw new ArgumentNullException(nameof(globalSkill)),
                    AllUserSkillsId = globalSkill.Id,
                    IsCheck = request.isCheck
                };

                await _userAccountSkillWriteRepository.AddAsync(newUserSkill);
            }

            await _userAccountSkillWriteRepository.SaveAsync();

            return Response<AddUserSkillCommandResponse>.Success("Başarılı bir şekilde eklendi.");
        }
        catch (Exception e)
        {
            return Response<AddUserSkillCommandResponse>.Fail(e.Message);
        }
    }



    public async Task<Response<List<AccountEducationDto>>> GetAccountEducation(GetAccountEducationCommandRequest request)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var educationList = await  _educationReadRepository.GetWhere(x => x.AppUserId == userId)
            .Select(ux=> new AccountEducationDto (){Id=ux.Id, Education = ux.Education})
            .ToListAsync();

        return Response<List<AccountEducationDto>>.Success(educationList);
    }

    public async Task<Response<List<AccountExperienceDto>>> GetAccountExperiences(GetAccountExperienceCommandRequest request)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var experiences = await _experiencesReadRepository.GetWhere(x => x.AppUserId == userId)
            .Select(ux=> new AccountExperienceDto(){Id=ux.Id,Experience = ux.Experiences}).ToListAsync();
        return  Response<List<AccountExperienceDto>>.Success(experiences);
    }

    public async Task<Response<GetAccountAboutCommandResponse>> GetAccountAbout(GetAccountAboutCommandRequest request)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var aboutList = await _aboutReadRepository.GetWhere(x => x.AppUserId == userId)
            .Select(ux => new GetAccountAboutCommandResponse { Biography = ux.Biography!, JobTitle = ux.JobTitle! })
            .SingleOrDefaultAsync();

        if (aboutList == null )
        {
            return Response<GetAccountAboutCommandResponse>.Fail("Veri çekerken başarısız oldu.");
        }

        return Response<GetAccountAboutCommandResponse>.Success(aboutList);
    }

    public async Task<Response<GetProfileImageCommandResponse>> GetAccountProfileImage()
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var profilePhoto = await _profileImageFileReadRepository.GetWhere(ux => ux.AppUserId == userId)
                .OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();

            GetProfileImageCommandResponse response = new GetProfileImageCommandResponse()
            {
                Path = $"{_configuration["BaseStorageUrl"]}/{profilePhoto.Path}",
                FileName = profilePhoto.FileName,
                GuidId = profilePhoto.Id
            };
            return Response<GetProfileImageCommandResponse>.Success(response);
        }
        catch (Exception e)
        {
            return Response<GetProfileImageCommandResponse>.Fail(e.Message);
        }
    }
    public async Task<Response<GetProfileBackgroundImageCommandResponse>> GetAccountProfileBackgroundImage()
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var backgroundImage = await _profileBackgroundImageReadRepository.GetWhere(ux => ux.AppUserId == userId)
                .OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();

            GetProfileBackgroundImageCommandResponse response = new GetProfileBackgroundImageCommandResponse()
            {
                Path = $"{_configuration["BaseStorageUrl"]}/{backgroundImage.Path}",
                FileName = backgroundImage.FileName,
                GuidId = backgroundImage.Id
            };
            return Response<GetProfileBackgroundImageCommandResponse>.Success(response);
        }
        catch (Exception e)
        {
            return Response<GetProfileBackgroundImageCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<List<AccountUserSkillsDto>>> GetAllUserSkills()
    {
        var response = await  _allUserAccountSkillReadRepository.GetWhere(x=>x.IsCheck).Select(ux =>
                       new AccountUserSkillsDto()
                       {
                Id = ux.Id.ToString(),
                isCheck = false,
                Skill = ux.Skill
            }).ToListAsync();
          return Response<List<AccountUserSkillsDto>>.Success(response);
    }

    public async Task<Response<List<AccountUserSkillsDto>>> GetUserSkills()
    {
        try
        {
            var userSkills = await _allUserAccountSkillReadRepository.GetWhere(ux => ux.IsCheck == true)
                .Select(ux=>
                    new AccountUserSkillsDto()
                    {
                        Id =ux.Id.ToString(),
                        isCheck = ux.IsCheck,Skill = ux.Skill
                    }).ToListAsync();
        
            return Response<List<AccountUserSkillsDto>>.Success(userSkills, null);
        }
        catch (Exception e)
        {
            return Response<List<AccountUserSkillsDto>>.Fail(e.Message);
        }
    }
    public async Task<Response<DeleteAccountEducationCommandResponse>> DeleteAccountEducation(DeleteAccountEducationCommandRequest request)
    {
        try
        { 
            await _educationWriteRepository.RemoveAsync(request.Id);
            await _unitOfWork.CommitIdentityAsync();
            return Response<DeleteAccountEducationCommandResponse>.Success( null,"Eğitim başarılı bir şekilde silindi");

        }
        catch (Exception e)
        {
            return Response<DeleteAccountEducationCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<DeleteAccountExperiencesCommandResponse>> DeleteAccountExperience(DeleteAccountExperiencesCommandRequest request)
    {
        try
        {
            await _experiencesWriteRepository.RemoveAsync(request.Id);
            await _unitOfWork.CommitIdentityAsync();
            return Response<DeleteAccountExperiencesCommandResponse>.Success("Experience başarılı bir şekilde silindi");
        }
        catch (Exception e)
        {
            return Response<DeleteAccountExperiencesCommandResponse>.Fail(e.Message);
        }
    }
    

    public async Task<Response<DeleteProfileImageCommandResponse>> DeleteAccountProfileImage()
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var userProfile = await _profileImageFileReadRepository.GetWhere(ux => ux.AppUserId == userId).FirstOrDefaultAsync();
            await _profileImageFileWriteRepository.RemoveAsync(userProfile!.Id.ToString());
            await _profileImageFileWriteRepository.SaveAsync();
            
            return Response<DeleteProfileImageCommandResponse>.Success("Resim silindi.");
        }
        catch (Exception e)
        {
            return Response<DeleteProfileImageCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<DeleteProfileBackgroundPhotoCommandResponse>> DeleteAccountProfileBackgroundImage()
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var userProfile = await _profileBackgroundImageReadRepository.GetWhere(ux => ux.AppUserId == userId).FirstOrDefaultAsync();
            await _profileBackgroundImageFileWriteRepository.RemoveAsync(userProfile!.Id.ToString());
            await _profileBackgroundImageFileWriteRepository.SaveAsync();
            
            return Response<DeleteProfileBackgroundPhotoCommandResponse>.Success("Resim silindi.");
        }
        catch (Exception e)
        {
            return Response<DeleteProfileBackgroundPhotoCommandResponse>.Fail(e.Message);
        }
    }
    
 
    
}