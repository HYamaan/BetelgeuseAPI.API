using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.AddAccountExperiences;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.DeleteAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Education.UpdateAccountEducation;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.DeleteAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.Experience.UpdateAccountExperience;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UpdateAccountAbout;
using BetelgeuseAPI.Application.Features.Commands.UserSettings.UploadAccountInformation;
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

    Task<Response<AddAccountExperiencesCommandResponse>> AddAccountExperiences(AddAccountExperiencesCommandRequest request);
    Task<Response<AddAccountEducationCommandResponse>> AddAccountEducation(AddAccountEducationCommandRequest request);
    Task<Response<List<AccountEducationDto>>> GetAccountEducation(GetAccountEducationCommandRequest request);
    Task<Response<List<AccountExperienceDto>>> GetAccountExperiences(GetAccountExperienceCommandRequest request);
    Task<Response<GetAccountAboutCommandResponse>> GetAccountAbout(GetAccountAboutCommandRequest request);

    Task<Response<DeleteAccountEducationCommandResponse>> DeleteAccountEducation(
        DeleteAccountEducationCommandRequest request);
    
    Task<Response<DeleteAccountExperiencesCommandResponse>> DeleteAccountExperience(
        DeleteAccountExperiencesCommandRequest request);


}