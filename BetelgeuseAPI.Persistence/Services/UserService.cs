using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UploadAccountInformation;
using BetelgeuseAPI.Application.Repositories.UserAccountInformation;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.Exceptions;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountExperiences;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.DeleteAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.UpdateAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.DeleteAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.UpdateAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UpdateAccountAbout;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountAbout;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountEducation;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountExperiences;
using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Application.Repositories.UserAccountEducation;
using BetelgeuseAPI.Application.Repositories.UserAccountExperiences;
using BetelgeuseAPI.Application.Repositories.UserAccountInformationAbout;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace BetelgeuseAPI.Persistence.Services;
public class UserService:IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserAccountInformationReadRepository _informationReadRepository;
    private readonly IUserAccountAboutReadRepository _aboutReadRepository;

    private readonly IUserAccountInformationWriteRepository _informationWriteRepository;
    private readonly IUserAccountExperiencesWriteRepository _experiencesWriteRepository;
    private readonly IUserAccountExperiencesReadRepository _experiencesReadRepository;
    private readonly IUserAccountEducationReadRepository _educationReadRepository;
    private readonly IUserAccountEducationWriteRepository _educationWriteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        UserManager<AppUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        IUserAccountInformationReadRepository informationReadRepository,
        IUserAccountAboutReadRepository aboutReadRepository,
        IUserAccountInformationWriteRepository informationWriteRepository,
        IUserAccountExperiencesWriteRepository experiencesWriteRepository,
        IUnitOfWork unitOfWork, IUserAccountExperiencesReadRepository experiencesReadRepository,
        IUserAccountEducationReadRepository educationReadRepository,
        IUserAccountEducationWriteRepository educationWriteRepository)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _informationReadRepository = informationReadRepository;
        _aboutReadRepository = aboutReadRepository;
        _informationWriteRepository = informationWriteRepository;
        _experiencesWriteRepository = experiencesWriteRepository;
        _unitOfWork = unitOfWork;
        _experiencesReadRepository = experiencesReadRepository;
        _educationReadRepository = educationReadRepository;
        _educationWriteRepository = educationWriteRepository;
    }

    public async Task<Response<UpdateAccountCommandResponse>> UpdateAccountInformation(UpdateAccountCommandRequest request)
    {
        var userId = GetUserIdFromContext();
        var user = await GetUserById(userId);

        var userInfo = await _informationReadRepository.GetByIdAsync(userId);
        if (userInfo is not null)
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
        var userId = GetUserIdFromContext();

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
        var userId = GetUserIdFromContext();
        var experiences = new UserAccountExperiences()
        {
            AppUserId = userId,
            Experiences = request.Experiences
        };
        await _experiencesWriteRepository.AddAsync(experiences);
        await _unitOfWork.CommitIdentityAsync();
        return Response<AddAccountExperiencesCommandResponse>.Success(null,
            "The experience has been successfully added");
    }

    public async Task<Response<AddAccountEducationCommandResponse>> AddAccountEducation(AddAccountEducationCommandRequest request)
    {
        var userId = GetUserIdFromContext();
        var education = new UserAccountEducation()
        {
            AppUserId = userId,
            Education = request.Education
        };
        await _educationWriteRepository.AddAsync(education);
        await _unitOfWork.CommitIdentityAsync();
        return Response<AddAccountEducationCommandResponse>.Success(null,
            "The experience has been successfully added");
    }

    public async Task<Response<List<AccountEducationDto>>> GetAccountEducation(GetAccountEducationCommandRequest request)
    {
        var userId = GetUserIdFromContext();
        var educationList = await  _educationReadRepository.GetWhere(x => x.AppUserId == userId)
            .Select(ux=> new AccountEducationDto (){Id=ux.Id, Education = ux.Education})
            .ToListAsync();

        return Response<List<AccountEducationDto>>.Success(educationList);
    }

    public async Task<Response<List<AccountExperienceDto>>> GetAccountExperiences(GetAccountExperienceCommandRequest request)
    {
        var userId = GetUserIdFromContext();
        var experiences = await _experiencesReadRepository.GetWhere(x => x.AppUserId == userId)
            .Select(ux=> new AccountExperienceDto(){Id=ux.Id,Experience = ux.Experiences}).ToListAsync();
        return  Response<List<AccountExperienceDto>>.Success(experiences);
    }

    public async Task<Response<GetAccountAboutCommandResponse>> GetAccountAbout(GetAccountAboutCommandRequest request)
    {
        var userId = GetUserIdFromContext();
        var aboutList = await _aboutReadRepository.GetWhere(x => x.AppUserId == userId)
            .Select(ux => new GetAccountAboutCommandResponse { Biography = ux.Biography!, JobTitle = ux.JobTitle! })
            .SingleOrDefaultAsync();

        if (aboutList == null )
        {
            return Response<GetAccountAboutCommandResponse>.Fail("Veri çekerken başarısız oldu.");
        }

        return Response<GetAccountAboutCommandResponse>.Success(aboutList);
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
    private string GetUserIdFromContext()
    {
        var userId = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException();
        }
        return userId;
    }
    private async Task<AppUser> GetUserById(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new ApiException("Kullanıcı bulunamadı");
        }
        return user;
    }
    
}