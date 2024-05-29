using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.Features.Commands.AppUser.QuizInteraction;
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
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UploadAccountInformation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UserSkill.AddUserSkill;
using BetelgeuseAPI.Application.Features.Queries.GetNotifications;
using BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileBackgroundImage;
using BetelgeuseAPI.Application.Features.Queries.ProfileImageFile.GetProfileImage;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountAbout;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountEducation;
using BetelgeuseAPI.Application.Features.Queries.UserSettings.GetAccountExperiences;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IUserService
{
    Task<Response<UpdateAccountCommandResponse>> UpdateAccountInformation(UpdateAccountCommandRequest request);
    Task<Response<UpdateAccountAboutCommandResponse>> UpdateAccountAbout(UpdateAccountAboutCommandRequest request);
    Task<Response<UpdateAccountEducationCommandResponse>> UpdateAccountEducation(UpdateAccountEducationCommandRequest request);
    Task<Response<UpdateAccountExperiencesCommandResponse>> UpdateAccountExperience(UpdateAccountExperiencesCommandRequest request);
    
    Task<Response<QuizInteractionCommandResponse>> UpdateQuizInteraction(QuizInteractionCommandRequest request);


    Task<Response<AddAccountExperiencesCommandResponse>> AddAccountExperiences(AddAccountExperiencesCommandRequest request);
    Task<Response<AddAccountEducationCommandResponse>> AddAccountEducation(AddAccountEducationCommandRequest request);
    Task<Response<UploadProfileImageCommandResponse>> AddProfilePhoto(UploadProfileImageCommandRequest request);
    Task<Response<UploadProfileBackgroundImageCommandResponse>> AddProfileBackgroundPhoto(UploadProfileBackgroundImageCommandRequest request);
    Task<Response<AddUserSkillCommandResponse>> AddUserSkill(AddUserSkillCommandRequest request);

    Task<Response<List<AccountEducationDto>>> GetAccountEducation(GetAccountEducationCommandRequest request);
    Task<Response<List<AccountExperienceDto>>> GetAccountExperiences(GetAccountExperienceCommandRequest request);
    Task<Response<GetAccountAboutCommandResponse>> GetAccountAbout(GetAccountAboutCommandRequest request);
    Task<Response<GetProfileImageCommandResponse>> GetAccountProfileImage();  
    Task<Response<GetProfileBackgroundImageCommandResponse>> GetAccountProfileBackgroundImage();
    Task<Response<List<AccountUserSkillsDto>>> GetAllUserSkills();
    Task<Response<List<AccountUserSkillsDto>>> GetUserSkills();
    Task<Response<GetNotificationsCommandResponse>> GetNotifications();

    Task<Response<DeleteAccountEducationCommandResponse>> DeleteAccountEducation(
        DeleteAccountEducationCommandRequest request);
    Task<Response<DeleteAccountExperiencesCommandResponse>> DeleteAccountExperience(
        DeleteAccountExperiencesCommandRequest request);
    Task<Response<DeleteProfileImageCommandResponse>> DeleteAccountProfileImage();
    Task<Response<DeleteProfileBackgroundPhotoCommandResponse>> DeleteAccountProfileBackgroundImage();
}