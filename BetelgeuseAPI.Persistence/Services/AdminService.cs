using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Services.Helpers;
using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.AddUserSkills;
using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.DeleteUserSkills;
using BetelgeuseAPI.Application.Features.Commands.Admin.Course.CourseControl;
using BetelgeuseAPI.Application.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Entities.Course;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Services;

public class AdminService : IAdminService
{
    private readonly IServicesHelper _servicesHelper;
    private readonly IAllUserAccountSkillWriteRepository _allUserAccountSkillWriteRepository;
    private readonly IAllUserAccountSkillReadRepository _allUserAccountSkillReadRepository;

    private readonly IInclusiveCourseReadRepository _inclusiveCourseRead;
    private readonly IInclusiveCourseWriteRepository _inclusiveCourseWrite;

    public AdminService(IAllUserAccountSkillWriteRepository allUserAccountSkillWriteRepository, IAllUserAccountSkillReadRepository allUserAccountSkillReadRepository, IServicesHelper servicesHelper, IInclusiveCourseReadRepository inclusiveCourseRead, IInclusiveCourseWriteRepository inclusiveCourseWrite)
    {
        _allUserAccountSkillWriteRepository = allUserAccountSkillWriteRepository;
        _allUserAccountSkillReadRepository = allUserAccountSkillReadRepository;
        _servicesHelper = servicesHelper;
        _inclusiveCourseRead = inclusiveCourseRead;
        _inclusiveCourseWrite = inclusiveCourseWrite;
    }

    public async Task<Response<AddAllUserSkillCommandResponse>> AddUserSkill(AddAllUserSkillCommandRequest request)
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();

            var response = await _allUserAccountSkillReadRepository
                .GetWhere(ux => ux.Skill.Trim().ToLower() == request.Skill.Trim().ToLower())
                .FirstOrDefaultAsync();

            if (response == null)
            {
                var newUserSkill = new AllUserSkills()
                {
                    Skill = request.Skill,
                    IsCheck = request.isCheck,
                };

                await _allUserAccountSkillWriteRepository.AddAsync(newUserSkill);
                await _allUserAccountSkillWriteRepository.SaveAsync();

                return Response<AddAllUserSkillCommandResponse>.Success("Yetenek Eklendi.");
            }
            else
            {
                return Response<AddAllUserSkillCommandResponse>.Fail("Bu yetenek zaten mevcut.");
            }
        }
        catch (Exception e)
        {
            return Response<AddAllUserSkillCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<CoursePublishedCommandResponse>> CoursePublished(CoursePublishedCommandRequest request)
    {
        var result = await GetCourseIdInformation(request.CourseId);

        if (result == null)
        {
            return Response<CoursePublishedCommandResponse>.Fail("Kurs bulunamadı.");
        }

        if (result.CourseExtraInformation == null ||
            result.CourseBasicInformation == null ||
            result.CoursePricing == null ||
            result.Sections == null ||
            result.MessageToReviewer == null ||
            result.AppUser == null)
        {
            result.Published = false;
            _inclusiveCourseWrite.Update(result);
            await _inclusiveCourseWrite.SaveAsync();
            return Response<CoursePublishedCommandResponse>.Fail("Kurs ekstra bilgileri bulunamadı.");
        }

        result.Published = request.Published;
        _inclusiveCourseWrite.Update(result);
        await _inclusiveCourseWrite.SaveAsync();


        return Response<CoursePublishedCommandResponse>.Success("Kurs Yayınlandı.");
    }

    public async Task<Response<DeleteAllUserSkillCommandResponse>> DeleteUserSkill(DeleteAllUserSkillCommandRequest request)
    {
        var skillId = await _allUserAccountSkillReadRepository.GetByIdAsync(request.Id);
        if (skillId == null)
        {
            return Response<DeleteAllUserSkillCommandResponse>.Fail("Yetenek Bulunamadı");
        }

        await _allUserAccountSkillWriteRepository.RemoveAsync(request.Id);
        await _allUserAccountSkillWriteRepository.SaveAsync();
        return Response<DeleteAllUserSkillCommandResponse>.Success("Yetenek başarılı bir şekilde silindi.");
    }


    private async Task<InclusiveCourse> GetCourseIdInformation(Guid courseId)
    {
        return await _inclusiveCourseRead.GetWhere(ux => ux.Id == courseId)
            .Include(ux => ux.CourseBasicInformation)
            .ThenInclude(ux => ux.Thumbnail)
            .Include(ux => ux.CourseBasicInformation)
            .ThenInclude(ux => ux.CoverImage)
            .Include(ux => ux.CourseExtraInformation)
            .ThenInclude(ux => ux.CourseSubLanguages)
            .Include(ux => ux.CoursePricing)
            .ThenInclude(x => x.NewCoursePricingPlan)
            .Include(ux => ux.Sections)
            .ThenInclude(ux => ux.CourseTypes)
            .ThenInclude(ct => ct.CourseSources)
            .ThenInclude(cs => cs.CourseSections)
            .Include(ux => ux.Sections)
            .ThenInclude(ux => ux.CourseTypes)
            .ThenInclude(ct => ct.CourseQuizzes)
            .ThenInclude(cs => cs.CourseQuestions)
            .ThenInclude(cs => cs.CourseQuizAnswers)

            .Include(ux => ux.Faqs)
            .Include(ux => ux.FaqLearningMaterial)
            .Include(ux => ux.FaqUploadLogo)
            .Include(ux => ux.FaqRequirements)
            .Include(ux => ux.MessageToReviewer)
            .Include(ux => ux.AppUser)
            .Include(ux => ux.Purchases)
            .FirstOrDefaultAsync();
    }

    private async Task<InclusiveCourse> GetAllCourseInformation()
    {
        return await _inclusiveCourseRead.GetAll()
            .Include(ux => ux.CourseBasicInformation)
            .ThenInclude(ux => ux.Thumbnail)
            .Include(ux => ux.CourseBasicInformation)
            .ThenInclude(ux => ux.CoverImage)
            .Include(ux => ux.CourseExtraInformation)
            .ThenInclude(ux => ux.CourseSubLanguages)
            .Include(ux => ux.CoursePricing)
            .ThenInclude(x => x.NewCoursePricingPlan)
            .Include(ux => ux.Sections)
            .ThenInclude(ux => ux.CourseTypes)
            .ThenInclude(ct => ct.CourseSources)
            .ThenInclude(cs => cs.CourseSections)
            .Include(ux => ux.Sections)
            .ThenInclude(ux => ux.CourseTypes)
            .ThenInclude(ct => ct.CourseQuizzes)
            .ThenInclude(cs => cs.CourseQuestions)
            .ThenInclude(cs => cs.CourseQuizAnswers)

            .Include(ux => ux.Faqs)
            .Include(ux => ux.FaqLearningMaterial)
            .Include(ux => ux.FaqUploadLogo)
            .Include(ux => ux.FaqRequirements)
            .Include(ux => ux.MessageToReviewer)
            .Include(ux => ux.AppUser)
            .Include(ux => ux.Purchases)
            .FirstOrDefaultAsync();
    }
}