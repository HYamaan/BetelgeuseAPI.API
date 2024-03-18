using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Features.Commands.Course.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.CoursePricing;
using BetelgeuseAPI.Application.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Application.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseCoverImage;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Domain.Entities.File;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Services;

public class CourseService : ICourseService
{
    private readonly IServicesHelper _servicesHelper;

    private readonly ICourseBasicInformationReadRepository _courseBasicInformationRead;
    private readonly ICourseBasicInformationWriteRepository _courseBasicInformationWrite;

    private readonly IInclusiveCourseReadRepository _inclusiveCourseRead;
    private readonly IInclusiveCourseWriteRepository _inclusiveCourseWrite;

    private readonly IImageService<CourseThumbnail, ICourseThumbnailReadRepository, ICourseThumbnailWriteRepository> _courseThumbnailService;
    public readonly IImageService<CourseCoverImage, ICourseCoverImageReadRepository, ICourseCoverImageWriteRepository> _courseCoverImageService;


    public CourseService(IServicesHelper servicesHelper, ICourseBasicInformationReadRepository courseBasicInformationRead, ICourseBasicInformationWriteRepository courseBasicInformationWrite, IInclusiveCourseReadRepository inclusiveCourseRead, IInclusiveCourseWriteRepository inclusiveCourseWrite, IImageService<CourseThumbnail, ICourseThumbnailReadRepository, ICourseThumbnailWriteRepository> courseThumbnailService, IImageService<CourseCoverImage, ICourseCoverImageReadRepository, ICourseCoverImageWriteRepository> courseCoverImageService)
    {
        _servicesHelper = servicesHelper;
        _courseBasicInformationRead = courseBasicInformationRead;
        _courseBasicInformationWrite = courseBasicInformationWrite;
        _inclusiveCourseRead = inclusiveCourseRead;
        _inclusiveCourseWrite = inclusiveCourseWrite;
        _courseThumbnailService = courseThumbnailService;
        _courseCoverImageService = courseCoverImageService;
    }

    public async Task<Response<BasicInformationCommandResponse>> AddCourseBasicInformation(BasicInformationCommandRequest model)
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var user = await _servicesHelper.GetUserById(userId);

            var inclusiveCourse = new InclusiveCourse();
            inclusiveCourse.CourseBasicInformation = new CourseBasicInformation();
            inclusiveCourse.CourseBasicInformation.Language = model.Language;
            inclusiveCourse.CourseBasicInformation.CourseType = model.CourseType;
            inclusiveCourse.CourseBasicInformation.SeoDescription = model.SeoDescription;
            inclusiveCourse.CourseBasicInformation.Title = model.Title;
            inclusiveCourse.CourseBasicInformation.Description = model.Description;

            var ThumbnailImage = await _courseThumbnailService.SaveImage(model.Thumbnail, userId);
            var CoverImage = await _courseCoverImageService.SaveImage(model.CoverImage, userId);

            inclusiveCourse.CourseBasicInformation.Thumbnail = ThumbnailImage;
            inclusiveCourse.CourseBasicInformation.CoverImage = CoverImage;
            inclusiveCourse.AppUser = user;

            await _inclusiveCourseWrite.AddAsync(inclusiveCourse);
            await _inclusiveCourseWrite.SaveAsync();
            return Response<BasicInformationCommandResponse>.Success("Course basic information added");
        }
        catch (Exception e)
        {
            return Response<BasicInformationCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<CourseExtraInformationCommandResponse>> AddCourseExtraInformation(CourseExtraInformationCommandRequest model)
    {
        try
        {
            var inclusiveCourse = await _inclusiveCourseRead.GetWhere(c => c.Id == model.CourseId)
                .Include(x => x.CourseBasicInformation)
                .Include(x => x.CourseExtraInformation)
                .Include(x => x.CoursePricing)
                .FirstOrDefaultAsync();
            if (inclusiveCourse == null)
            {
                throw new Exception("Course not found");
            }

            inclusiveCourse.CourseExtraInformation = new CourseExtraInformation
            {
                CategoryId = model.CategoryId,
                Duration = model.Duration,
                IsCourseForm = model.IsCourseForm,
                IsSupport = model.IsSupport,
                IsDownloadable = model.IsDownloadable,
                IsPartnered = model.IsPartnered,
                Tag = model.Tag,
                CourseLevel = model.CourseLevel,
            };
            if (model.CourseSubLanguages != null && model.CourseSubLanguages.Any())
            {
                inclusiveCourse.CourseExtraInformation.CourseSubLanguage = string.Join(",",
                    model.CourseSubLanguages.Select(csl => csl.language.ToString()));

            }

            if (model.IsPartnered)
            {
                //var partners = new List<AppUser>();
                //foreach (var partner in model.PartnersId)
                //{
                //    var newPartner = await _servicesHelper.GetUserById(partner.partnerId.ToString());
                //    partners.Add(newPartner);
                //}

                //inclusiveCourse.CourseExtraInformation.Partners = partners;
                var newPartner = await _servicesHelper.GetUserById(model.PartnerId.ToString());
                inclusiveCourse.CourseExtraInformation.Partner = newPartner;
            }

            _inclusiveCourseWrite.Update(inclusiveCourse);
            await _inclusiveCourseWrite.SaveAsync();

            return Response<CourseExtraInformationCommandResponse>.Success("Course extra information added");
        }
        catch (Exception e)
        {
            return Response<CourseExtraInformationCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<CoursePricingCommandResponse>> AddCoursePricing(CoursePricingCommandRequest model)
    {
        try
        {
            var inclusiveCourse = await _inclusiveCourseRead.GetWhere(c => c.Id == model.CourseId)
                .Include(x => x.CourseBasicInformation)
                .Include(x => x.CourseExtraInformation)
                .Include(x => x.CoursePricing)
                .ThenInclude(x => x.NewCoursePricingPlan)
                .FirstOrDefaultAsync();
            if (inclusiveCourse == null)
            {
                throw new Exception("Course not found");
            }

            if (inclusiveCourse.CoursePricing == null)
            {
                inclusiveCourse.CoursePricing = new CoursePricing();
            }
               

            inclusiveCourse.CoursePricing.Price = model.Price;
            inclusiveCourse.CoursePricing.IsFree = model?.IsFree ?? false;

            if (inclusiveCourse.CoursePricing.IsFree)
            {
                inclusiveCourse.CoursePricing.Price = 0;
            }
          
               

            if (model.NewCoursePricingPlanRequestDto != null && model.NewCoursePricingPlanRequestDto.Any())
            {
                inclusiveCourse.CoursePricing.NewCoursePricingPlan.RemoveAll(plan => plan.CoursePricingId == inclusiveCourse.CoursePricingId);
                inclusiveCourse.CoursePricing.NewCoursePricingPlan = new List<NewCoursePricingPlan>();

                foreach (var planDto in model.NewCoursePricingPlanRequestDto)
                {
                    inclusiveCourse.CoursePricing.NewCoursePricingPlan.Add(new NewCoursePricingPlan
                    {
                        Title = planDto.Title,
                        Discount = planDto.Discount,
                        Capacity = planDto.Capacity,
                        Price = planDto.Price,
                        StartDate = planDto.StartDate,
                        EndDate = planDto.EndDate,
                        Language = planDto.Language.language
                    });
                }
            }

            _inclusiveCourseWrite.Update(inclusiveCourse);
            await _inclusiveCourseWrite.SaveAsync();
            return Response<CoursePricingCommandResponse>.Success("Course pricing added");
        }
        catch (Exception e)
        {
           return Response<CoursePricingCommandResponse>.Fail(e.Message);
        }
    }

}