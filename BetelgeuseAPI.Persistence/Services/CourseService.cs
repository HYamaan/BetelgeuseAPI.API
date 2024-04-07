using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CoursePricing;
using BetelgeuseAPI.Application.Repositories.Course.BasicInformation;
using BetelgeuseAPI.Application.Repositories.Course.CourseContent;
using BetelgeuseAPI.Application.Repositories.Course.CourseSource;
using BetelgeuseAPI.Application.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseCoverImage;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseThumbnail;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseUpload;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Domain.Entities.Course.Content;
using BetelgeuseAPI.Domain.Entities.File;
using BetelgeuseAPI.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using BetelgeuseAPI.Application.Abstractions.Services.Helpers;
using BetelgeuseAPI.Application.DTOs.Request;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.UploadCourseQuiz;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.UpdateCourseSection;
using BetelgeuseAPI.Application.Repositories.Course.CourseExtraInformation;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuiz;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuizAnswer;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseQuizQuestionVideo;
using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.CourseQuestion.UpdateCourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.DeleteCourseQuestion;
using BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuestion;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuizUpload;
using BetelgeuseAPI.Domain.Auth;
using Microsoft.AspNetCore.Http;
using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Application.Features.Queries.Course.GetContent;
using BetelgeuseAPI.Application.Features.Queries.Course.GetExtraInformation;
using BetelgeuseAPI.Application.Features.Queries.Course.GetPricing;
using System.Linq;
using BetelgeuseAPI.Application.DTOs.Request.Course;
using BetelgeuseAPI.Application.DTOs.Request.Course.LearningPage;
using BetelgeuseAPI.Application.DTOs.Response.Course.CourseDetail;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseQuiz;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseSections;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseSource;
using BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseTypeOrder;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteComponyLogo;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteFaq;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteFaqLearningMaterial;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.DeleteRequirements;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.FaqTypeOrder;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadCompanyLogo;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadFaq;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadLearningMaterial;
using BetelgeuseAPI.Application.Features.Commands.Course.FAQ.UploadRequirements;
using BetelgeuseAPI.Application.Features.Queries.Course.GetQuizAndCertification;
using BetelgeuseAPI.Application.Repositories.Course.Faq;
using BetelgeuseAPI.Application.Repositories.Course.FaqLearningMaterial;
using BetelgeuseAPI.Application.Repositories.Course.FaqRequirements;
using BetelgeuseAPI.Application.Repositories.FileContent.FaqUploadLogo;
using BetelgeuseAPI.Domain.Entities.Course.FAQ;
using BetelgeuseAPI.Domain.Entities.Course.Pricing;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.DeleteCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.MessageToReview;
using BetelgeuseAPI.Application.Features.Queries.Course.CoursesPage;
using BetelgeuseAPI.Application.Features.Queries.Course.GetCourseDetailPage;
using BetelgeuseAPI.Application.Features.Queries.Course.GetCourseLearningPage;
using BetelgeuseAPI.Application.Repositories.Course.CourseSubLanguage;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Entities.Purchase;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto.Engines;


namespace BetelgeuseAPI.Persistence.Services;

public class CourseService : ICourseService
{
    private readonly IServicesHelper _servicesHelper;
    private readonly IStorageService _storageService;
    private readonly IFileCheckHelper _fileCheckHelper;

    private readonly ICourseBasicInformationReadRepository _courseBasicInformationRead;
    private readonly ICourseBasicInformationWriteRepository _courseBasicInformationWrite;

    private readonly ICourseContentSectionReadRepository _courseSectionRead;
    private readonly ICourseContentSectionWriteRepository _courseSectionWrite;

    private readonly ICourseSourceReadRepository _courseSourceRead;
    private readonly ICourseSourceWriteRepository _courseSourceWrite;

    private readonly ICourseUploadReadRepository _uploadFileReadRepository;
    private readonly ICourseUploadWriteRepository _UploadFileWriteRepository;

    private readonly IInclusiveCourseReadRepository _inclusiveCourseRead;
    private readonly IInclusiveCourseWriteRepository _inclusiveCourseWrite;

    private readonly ICourseQuizesReadRepository _courseQuizesRead;
    private readonly ICourseQuizesWriteRepository _courseQuizesWrite;

    private readonly ICourseQuizQuestionVideoReadRepository _courseQuizQuestionVideoRead;
    private readonly ICourseQuizQuestionVideoWriteRepository _courseQuizQuestionVideoWrite;

    private readonly ICourseQuizAnswerReadRepository _courseQuizAnswerRead;
    private readonly ICourseQuizAnswerWriteRepository _courseQuizAnswerWrite;

    private readonly ICourseExtraInformationReadRepository _courseExtraInformationRead;
    private readonly ICourseExtraInformationWriteRepository _courseExtraInformationWrite;

    private readonly ICourseQuestionReadRepository _courseQuizQuestionRead;
    private readonly ICourseQuestionWriteRepository _courseQuizQuestionWrite;


    private readonly ICourseQuizUploadReadRepository _courseQuizUploadRead;
    private readonly ICourseQuizUploadWriteRepository _courseQuizUploadWrite;

    private readonly IFaqUploadLogoReadRepository _faqUploadLogoRead;
    private readonly IFaqUploadLogoWriteRepository _faqUploadLogoWrite;

    private readonly IFaqOptionReadRepository _faqOptionRead;
    private readonly IFaqOptionWriteRepository _faqOptionWrite;

    private readonly IFaqRequirementsReadRepository _faqRequirementsRead;
    private readonly IFaqRequirementsWriteRepository _faqRequirementsWrite;

    private readonly IFaqLearningMaterialReadRepository _faqLearningMaterialRead;
    private readonly IFaqLearningMaterialWriteRepository _faqLearningMaterialWrite;

    private readonly ICourseSubLanguageReadRepository _courseSubLanguageRead;
    private readonly ICourseSubLanguageWriteRepository _courseSubLanguageWrite;



    private readonly IImageService<CourseThumbnail,ICourseThumbnailReadRepository,ICourseThumbnailWriteRepository> _courseThumbnailService;
    private readonly IImageService<CourseCoverImage,ICourseCoverImageReadRepository,ICourseCoverImageWriteRepository> _courseCoverImageService;



    public CourseService(IServicesHelper servicesHelper,
        IStorageService storageService,
        ICourseBasicInformationReadRepository courseBasicInformationRead,
        ICourseBasicInformationWriteRepository courseBasicInformationWrite,
        IInclusiveCourseReadRepository inclusiveCourseRead, IInclusiveCourseWriteRepository inclusiveCourseWrite,
        ICourseContentSectionWriteRepository courseSectionWrite,
        ICourseContentSectionReadRepository courseSectionRead,
        ICourseSourceWriteRepository courseSourceWrite,
        ICourseSourceReadRepository courseSourceRead,
        ICourseUploadReadRepository uploadFileReadRepository,
        ICourseUploadWriteRepository uploadFileWriteRepository,
        IFileCheckHelper fileCheckHelper,
        ICourseQuizesReadRepository courseQuizesRead,
        ICourseQuizesWriteRepository courseQuizesWrite,
        ICourseQuizQuestionVideoReadRepository courseQuizQuestionVideoRead,
        ICourseQuizQuestionVideoWriteRepository courseQuizQuestionVideoWrite,
        ICourseQuizAnswerWriteRepository courseQuizAnswerWrite,
        ICourseQuizAnswerReadRepository courseQuizAnswerRead,
        ICourseExtraInformationWriteRepository courseExtraInformationWrite,
        ICourseExtraInformationReadRepository courseExtraInformationRead,
        ICourseQuestionWriteRepository courseQuizQuestionWrite, 
        ICourseQuestionReadRepository courseQuizQuestionRead,
        ICourseQuizUploadReadRepository courseQuizUploadRead, 
        ICourseQuizUploadWriteRepository courseQuizUploadWrite, 
        IFaqUploadLogoReadRepository faqUploadLogoRead,
        IFaqUploadLogoWriteRepository faqUploadLogoWrite,
        IFaqOptionReadRepository faqOptionRead,
        IFaqOptionWriteRepository faqOptionWrite, 
        IFaqRequirementsReadRepository faqRequirementsRead,
        IFaqRequirementsWriteRepository faqRequirementsWrite,
        IFaqLearningMaterialReadRepository faqLearningMaterialRead,
        IFaqLearningMaterialWriteRepository faqLearningMaterialWrite,
        ICourseSubLanguageReadRepository courseSubLanguageRead,
        ICourseSubLanguageWriteRepository courseSubLanguageWrite,
        IImageService<CourseThumbnail, ICourseThumbnailReadRepository, ICourseThumbnailWriteRepository> courseThumbnailService,
        IImageService<CourseCoverImage, ICourseCoverImageReadRepository, ICourseCoverImageWriteRepository> courseCoverImageService)
    {
        _servicesHelper = servicesHelper;
        _courseBasicInformationRead = courseBasicInformationRead;
        _courseBasicInformationWrite = courseBasicInformationWrite;
        _inclusiveCourseRead = inclusiveCourseRead;
        _inclusiveCourseWrite = inclusiveCourseWrite;
        _courseSectionWrite = courseSectionWrite;
        _courseSectionRead = courseSectionRead;
        _courseSourceWrite = courseSourceWrite;
        _courseSourceRead = courseSourceRead;
        _uploadFileReadRepository = uploadFileReadRepository;
        _UploadFileWriteRepository = uploadFileWriteRepository;
        _fileCheckHelper = fileCheckHelper;
        _courseQuizesRead = courseQuizesRead;
        _courseQuizesWrite = courseQuizesWrite;
        _courseQuizQuestionVideoRead = courseQuizQuestionVideoRead;
        _courseQuizQuestionVideoWrite = courseQuizQuestionVideoWrite;
        _courseQuizAnswerWrite = courseQuizAnswerWrite;
        _courseQuizAnswerRead = courseQuizAnswerRead;
        _courseExtraInformationWrite = courseExtraInformationWrite;
        _courseExtraInformationRead = courseExtraInformationRead;
        _courseQuizQuestionWrite = courseQuizQuestionWrite;
        _courseQuizQuestionRead = courseQuizQuestionRead;
        _courseQuizUploadRead = courseQuizUploadRead;
        _courseQuizUploadWrite = courseQuizUploadWrite;
        _faqUploadLogoRead = faqUploadLogoRead;
        _faqUploadLogoWrite = faqUploadLogoWrite;
        _faqOptionRead = faqOptionRead;
        _faqOptionWrite = faqOptionWrite;
        _faqRequirementsRead = faqRequirementsRead;
        _faqRequirementsWrite = faqRequirementsWrite;
        _faqLearningMaterialRead = faqLearningMaterialRead;
        _faqLearningMaterialWrite = faqLearningMaterialWrite;
        _courseSubLanguageRead = courseSubLanguageRead;
        _courseSubLanguageWrite = courseSubLanguageWrite;
        _courseThumbnailService = courseThumbnailService;
        _courseCoverImageService = courseCoverImageService;

        _storageService = storageService;
    }
    public async Task<Response<BasicInformationCommandResponse>> AddCourseBasicInformation(
      BasicInformationCommandRequest model)
    {
        try
        {
            var defaultValue = false;
            var userId = _servicesHelper.GetUserIdFromContext();
            var user = await _servicesHelper.GetUserById(userId);
            var inclusiveCourse = new InclusiveCourse();
            inclusiveCourse.CourseBasicInformation = new CourseBasicInformation();

            if (model?.CourseId != null)
            {
                var result = await _inclusiveCourseRead.GetWhere(c => c.Id == model.CourseId)
                    .Include(x => x.CourseBasicInformation)
                    .FirstOrDefaultAsync();
                if (result != null) inclusiveCourse = result;
                defaultValue = true;
            }


            inclusiveCourse.CourseBasicInformation.Language = model.Language;
            inclusiveCourse.CourseBasicInformation.CourseType = model.CourseType;
            inclusiveCourse.CourseBasicInformation.SeoDescription = model.SeoDescription;
            inclusiveCourse.CourseBasicInformation.Title = model.Title;
            inclusiveCourse.CourseBasicInformation.Description = model.Description;

            var ThumbnailImage = await _courseThumbnailService.UpdateImage(model.Thumbnail, userId);
            var CoverImage = await _courseCoverImageService.UpdateImage(model.CoverImage, userId);

            inclusiveCourse.CourseBasicInformation.Thumbnail = ThumbnailImage;
            inclusiveCourse.CourseBasicInformation.CoverImage = CoverImage;
            inclusiveCourse.AppUser = user;

            if (defaultValue)
            {
                _inclusiveCourseWrite.Update(inclusiveCourse);
            }
            else
            {
                await _inclusiveCourseWrite.AddAsync(inclusiveCourse);
            }
            await _inclusiveCourseWrite.SaveAsync();
            return Response<BasicInformationCommandResponse>.Success("Course basic information added");
        }
        catch (Exception e)
        {
            return Response<BasicInformationCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<CourseExtraInformationCommandResponse>> AddCourseExtraInformation(
        CourseExtraInformationCommandRequest model)
    {
        try
        {
            var inclusiveCourse = await _inclusiveCourseRead.GetWhere(c => c.Id == model.CourseId)
              .Include(x => x.CourseExtraInformation)
              .ThenInclude(x=>x.CourseSubLanguages)
              .FirstOrDefaultAsync();

            var defaultValue = false;
            var courseExtraInformation = new CourseExtraInformation();
            if (inclusiveCourse.CourseExtraInformation != null)
            {
                courseExtraInformation = inclusiveCourse.CourseExtraInformation;
                defaultValue = true;
            }


            courseExtraInformation.InclusiveCourseId = model.CourseId;
            courseExtraInformation.CategoryId = model.CategoryId;
            courseExtraInformation.Duration = model.Duration;
            courseExtraInformation.IsCourseForm = model.IsCourseForm;
            courseExtraInformation.IsCertificate = model.IsCertificate;
            courseExtraInformation.IsSupport = model.IsSupport;
            courseExtraInformation.IsDownloadable = model.IsDownloadable;
            courseExtraInformation.IsPartnered = model.IsPartnered;
            courseExtraInformation.CourseLevel = model.CourseLevel;

            if (model.Tag != null)
            {
                courseExtraInformation.Tag = string.Join(",", model.Tag.Select(ux => ux.Tag.ToString()));
            }
            if (model.CourseSubLanguages != null && model.CourseSubLanguages.Any())
            {
                if (courseExtraInformation.CourseSubLanguages == null)
                {
                    courseExtraInformation.CourseSubLanguages = new List<CourseSubLanguage>();
                }
                else
                {
                    var courseSubLanguagesCopy = courseExtraInformation.CourseSubLanguages.ToList();

                    foreach (var init in courseSubLanguagesCopy)
                    {
                        var result = model.CourseSubLanguages.Any(x => (int)x.language == init.LanguageId);
                        if (!result)
                        {
                            _courseSubLanguageWrite.Remove(init);
                        }
                    }
                }
                foreach (var language in model.CourseSubLanguages)
                {
                    if (!courseExtraInformation.CourseSubLanguages.Any(x => x.LanguageId == (int)language.language))
                    {
                        courseExtraInformation.CourseSubLanguages.Add(new CourseSubLanguage
                        {
                            LanguageId = (int)language.language,
                            CourseExtraInformation = courseExtraInformation
                        });
                    }
                }
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
                courseExtraInformation.Partner = newPartner;
            }

            if (defaultValue)
            {
                _courseExtraInformationWrite.Update(courseExtraInformation);
            }
            else
            {
                await _courseExtraInformationWrite.AddAsync(courseExtraInformation);
            }

            await _courseExtraInformationWrite.SaveAsync();

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
            var inclusiveCourse = await GetInclusiveCourse(model.CourseId);
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
                if (inclusiveCourse.CoursePricingId is not null)
                {
                    inclusiveCourse.CoursePricing.NewCoursePricingPlan.RemoveAll(plan =>
                        plan.CoursePricingId == inclusiveCourse.CoursePricingId);
                }

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
                        Language = planDto.Language
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

    public async Task<Response<CourseSectionsCommandResponse>> AddCourseSections(CourseSectionsCommandRequest model)
    {
        var inclusiveCourse = await _inclusiveCourseRead.GetWhere(c => c.Id == model.CourseId).Include(x => x.Sections).FirstOrDefaultAsync();
        var defaultValue = false;
        var courseSection = new CourseSections();
        if (inclusiveCourse.Sections == null)
        {
            return Response<CourseSectionsCommandResponse>.Fail("Course not found");
        }
        if (inclusiveCourse.Sections == null)
        {
            inclusiveCourse.Sections = new List<CourseSections>(); // Initialize the Sections list
        }
        var newSection = new CourseSections()
        {
            Order = model.Order,
            Title = model.Title,
            LanguageId = model.LanguageId,
            IsActive = model.IsActive,
            PassAllParts = model.PassAllParts,
        };
        inclusiveCourse.Sections.Add(newSection);
        _inclusiveCourseWrite.Update(inclusiveCourse);
        await _inclusiveCourseWrite.SaveAsync();
        return Response<CourseSectionsCommandResponse>.Success("Course section added");
    }


    public async Task<Response<CourseSourceCommandResponse>> AddCourseSource(CourseSourceCommandRequest model)
    {
        try
        {
            var inclusiveCourse = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
                .Include(x => x.Sections)
                .ThenInclude(x => x.CourseTypes).FirstOrDefaultAsync();

            if (inclusiveCourse == null)
            {
                return Response<CourseSourceCommandResponse>.Fail("Course not found");
            }

            var section = inclusiveCourse?.Sections?.FirstOrDefault(s => s.Id == model.SectionId);

            if (section == null)
            {
                return Response<CourseSourceCommandResponse>.Fail("Section not found");
            }


            var newCourseSource = new CourseSource
            {
                Order = model.Order,
                Title = model.Title,
                LanguageId = model.LanguageId,
                IsActive = model.IsActive,
                IsFree = model.IsFree,
                Description = model.Description,
                Source = model.Source,
                FileType = model.FileType,
                CourseSections = section
            };

            if (model.Source == CourseUploadSourceType.Upload || model.Source == CourseUploadSourceType.AmazonS3)
            {
                var userId = _servicesHelper.GetUserIdFromContext();
                var user = await _servicesHelper.GetUserById(userId);
                if (model.FileType == CourseUploadFileType.Video &&
                    await _fileCheckHelper.CheckVideoFormat(model.uploadFile))
                {

                    var data = await _storageService.UploadVideoAsync("files", model.uploadFile);

                    var courseUploads = data.Select(d => new CourseUpload
                    {
                        FileName = d.fileName,
                        Path = d.pathOrContainerName,
                        Storage = _storageService.StorageName,
                        AppUser = user
                    }).ToList();

                    await _UploadFileWriteRepository.AddRangeAsync(courseUploads);
                    await _UploadFileWriteRepository.SaveAsync();

                    newCourseSource.CourseUpload = courseUploads;
                }
                else if ((model.FileType == CourseUploadFileType.Pdf &&
                          await _fileCheckHelper.CheckPdfFormat(model.uploadFile)) ||
                         (model.FileType == CourseUploadFileType.PowerPoint &&
                          await _fileCheckHelper.CheckPPTFormat(model.uploadFile)) ||
                         (model.FileType == CourseUploadFileType.Image &&
                          await _fileCheckHelper.CheckImageFormat(model.uploadFile))
                        )
                {
                    var data = await _storageService.UploadAsync("files", model.uploadFile);
                    var courseUploads = new CourseUpload
                    {
                        FileName = data.fileName,
                        Path = data.pathOrContainerName,
                        Storage = _storageService.StorageName,
                        AppUser = user
                    };

                    await _UploadFileWriteRepository.AddAsync(courseUploads);
                    await _UploadFileWriteRepository.SaveAsync();
                    newCourseSource.CourseUpload = new List<CourseUpload> { courseUploads };

                }
                else
                {
                    return Response<CourseSourceCommandResponse>.Fail($"Invalid {model.uploadFile.FileName} format");
                }
            }
            else
            {
                if (model.Source != null)
                {
                    newCourseSource.Link = model.Link;
                }
            }

            section.CourseTypes ??= new List<CourseType>();
            section.CourseTypes.Add(new CourseType
            {
                CourseSources = newCourseSource,
                Order = model.Order
            });

            _inclusiveCourseWrite.Update(inclusiveCourse);
            await _inclusiveCourseWrite.SaveAsync();

            return Response<CourseSourceCommandResponse>.Success("Course source added");
        }
        catch (Exception e)
        {
            return Response<CourseSourceCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<CourseQuizCommandResponse>> AddCourseQuiz(CourseQuizCommandRequest model)
    {

        var findSection = await _courseSectionRead.GetWhere(ux => ux.Id == model.SectionId)
            .Include(x => x.CourseTypes)
            .FirstOrDefaultAsync();

        if (findSection == null)
        {
            return Response<CourseQuizCommandResponse>.Fail("Section not found");
        }

        var newQuiz = new CourseQuiz()
        {
            Order = model.Order,
            Attempts = model?.Attempts,
            Language = model.Language,
            Title = model.Title,
            Time = model.Time ?? 0,
            PassingScore = model.PassingScore,
            ExpiryDate = model?.ExpiryDate,
            LimitedQuestion = model.LimitedQuestion,
            RandomizeQuestion = model.RandomizeQuestion,
            QuestionCount = model?.QuestionCount,
            Certificate = model.Certificate,
            IsActive = model.IsActive,
            CourseSections = findSection
        };
        findSection.CourseTypes ??= new List<CourseType>();
        findSection.CourseTypes.Add(new CourseType
        {
            CourseQuizzes = newQuiz,
            Order = model.Order
        });
        _courseSectionWrite.Update(findSection);
        await _courseSectionWrite.SaveAsync();

        return Response<CourseQuizCommandResponse>.Success("Course quiz added");
    }

    public async Task<Response<CourseQuestionCommandResponse>> AddCourseQuestion(CourseQuestionCommandRequest model)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var user = await _servicesHelper.GetUserById(userId);


        var newQuestion = new CourseQuestions()
        {
            Id = Guid.NewGuid(),
            LanguageId = model.LanguageId,
            Title = model.Title,
            Grade = model.Grade,
            QuestionType = model.QuestionType,
            CourseQuizAnswers = new List<CourseQuizAnswer>(),
            CourseQuizId = model.quizId
        };
        if (model.Image != null && await _fileCheckHelper.CheckImageFormat(model.Image))
        {
            var result = await UpdateQuizQuestionImage(model.Image, user, newQuestion);

            newQuestion.Image = result;
        }
        else if (model.Video != null && await _fileCheckHelper.CheckVideoFormat(model.Video))
        {
            var data = await _storageService.UploadVideoAsync("files", model.Video);

            var courseUploads = data.Select(d => new CourseQuizUpload
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName,
                AppUser = user
            }).ToList();

            await _courseQuizUploadWrite.AddRangeAsync(courseUploads);
            await _courseQuizUploadWrite.SaveAsync();
            newQuestion.Video = courseUploads;
        }
        if (model.QuizAnswers != null && model.QuizAnswers.Any())
        {

            foreach (var answer in model.QuizAnswers)
            {
                var newAnswer = new CourseQuizAnswer()
                {
                    Title = answer?.Title,
                    IsCorrect = answer.IsCorrect ?? false,
                    Description = answer?.Description,
                    CourseQuestionId = newQuestion.Id,
                    CourseQuestion = newQuestion
                };

                newQuestion.CourseQuizAnswers.Add(newAnswer);
                await _courseQuizAnswerWrite.AddAsync(newAnswer);
            }
        }
        await _courseQuizAnswerWrite.SaveAsync();

        return Response<CourseQuestionCommandResponse>.Success("Course question added");
    }

    public async Task<Response<MessageToReviewCommandResponse>> AddMessageToReview(MessageToReviewCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(c => c.Id == model.CourseId)
            .Include(x => x.MessageToReviewer)
            .Include(x => x.Purchases)
            .FirstOrDefaultAsync();

        if (result == null)
        {
            return Response<MessageToReviewCommandResponse>.Fail("Course not found");
        }

        if (result.MessageToReviewer == null)
        {
            result.MessageToReviewer = new MessageToReviewer();
        }

        result.MessageToReviewer.Message = model.Message;
        result.MessageToReviewer.Rules = model.Rules;
        result.isActive = true;
        var userId = _servicesHelper.GetUserIdFromContext();

        var purchase = new Purchase
        {
            AppUserId = userId,
            InclusiveCourseId = model.CourseId
        };
        result.Purchases.Add(purchase);
        _inclusiveCourseWrite.Update(result);
        await _inclusiveCourseWrite.SaveAsync();


        return Response<MessageToReviewCommandResponse>.Success("Message to review added");

    }

    public async Task<Response<UpdateCourseSectionCommandResponse>> UpdateCourseSection(UpdateCourseSectionCommandRequest model)
    {
        var findCourse = await _inclusiveCourseRead.GetByIdAsync(model.CourseId.ToString());
        if (findCourse == null)
        {
            return Response<UpdateCourseSectionCommandResponse>.Fail("Invalid CourseId");
        }

        var findSection = await _courseSectionRead.GetByIdAsync(model.CourseSectionId.ToString());
        if (findSection == null)
        {
            return Response<UpdateCourseSectionCommandResponse>.Fail("Invalid SectionId");
        }

        // Güncelleme için gönderilen her özellik için modeldeki değeri kontrol et, yoksa mevcut veriyi koru
        findSection.LanguageId = model.LanguageId ?? findSection.LanguageId;
        findSection.Title = model.Title ?? findSection.Title;
        findSection.IsActive = model.IsActive ?? findSection.IsActive;
        findSection.PassAllParts = model.PassAllParts ?? findSection.PassAllParts;

        _courseSectionWrite.Update(findSection);
        await _courseSectionWrite.SaveAsync();

        return Response<UpdateCourseSectionCommandResponse>.Success("Course section updated");
    }

    public async Task<Response<UploadCourseQuizCommandResponse>> UploadCourseQuiz(UploadCourseQuizCommandRequest model)
    {
        var findSection = await _courseSectionRead.GetByIdAsync(model.SectionId.ToString());
        if (findSection == null)
        {
            return Response<UploadCourseQuizCommandResponse>.Fail("Section not found");
        }
        var findQuiz = await _courseQuizesRead.GetWhere(q => q.Id == model.QuizId).FirstOrDefaultAsync();
        if (findQuiz == null)
        {
            return Response<UploadCourseQuizCommandResponse>.Fail("Quiz not found");
        }
        findSection.CourseTypes = new List<CourseType>();
        findSection.CourseTypes.Add(new CourseType
        {
            CourseQuizzes = findQuiz,
            Order = model.Order
        });
        findQuiz.Attempts = model.Attempts ?? findQuiz.Attempts;
        findQuiz.Language = model.Language ?? findQuiz.Language;
        findQuiz.Title = model.Title ?? findQuiz.Title;
        findQuiz.Time = model.Time ?? findQuiz.Time;
        findQuiz.PassingScore = model.PassingScore ?? findQuiz.PassingScore;
        findQuiz.ExpiryDate = model.ExpiryDate ?? findQuiz.ExpiryDate;
        findQuiz.LimitedQuestion = model.LimitedQuestion ?? findQuiz.LimitedQuestion;
        findQuiz.RandomizeQuestion = model.RandomizeQuestion ?? findQuiz.RandomizeQuestion;
        findQuiz.QuestionCount = model.QuestionCount ?? findQuiz.QuestionCount;
        findQuiz.Certificate = model.Certificate ?? findQuiz.Certificate;
        findQuiz.IsActive = model.IsActive ?? findQuiz.IsActive;
        findQuiz.CourseSections = findSection;

        _courseSectionWrite.Update(findSection);
        _courseQuizesWrite.Update(findQuiz);
        await _courseQuizesWrite.SaveAsync();
        await _courseSectionWrite.SaveAsync();
        return Response<UploadCourseQuizCommandResponse>.Success("Course quiz updated");
    }

    public async Task<Response<UpdateCourseQuestionCommandResponse>> UpdateCourseQuestion(UpdateCourseQuestionCommandRequest model)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var user = await _servicesHelper.GetUserById(userId);

        var findQuiz = await _courseQuizesRead.GetWhere(q => q.Id == model.quizId).FirstOrDefaultAsync();
        if (findQuiz == null)
        {
            return Response<UpdateCourseQuestionCommandResponse>.Fail("Quiz not found");
        }

        var findQuestion = await _courseQuizQuestionRead.GetWhere(q => q.Id == model.questionId)
            .Include(x => x.Image)
            .Include(x => x.Video)
            .Include(x => x.CourseQuizAnswers)
            .FirstOrDefaultAsync();

        if (findQuestion == null)
        {
            return Response<UpdateCourseQuestionCommandResponse>.Fail("Question not found");
        }

        findQuestion.LanguageId = model.LanguageId ?? findQuestion.LanguageId;
        findQuestion.Title = model.Title ?? findQuestion.Title;
        findQuestion.Grade = model.Grade ?? findQuestion.Grade;
        findQuestion.QuestionType = model.QuestionType ?? findQuestion.QuestionType;

        if (model.Image != null && await _fileCheckHelper.CheckImageFormat(model.Image))
        {
            var result = await UpdateQuizQuestionImage(model.Image, user, findQuestion);
            findQuestion.Image = result;
        }
        else if (model.Video != null && await _fileCheckHelper.CheckVideoFormat(model.Video))
        {
            var data = await _storageService.UploadVideoAsync("files", model.Video);

            var courseUploads = data.Select(d => new CourseQuizUpload
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName,
                AppUser = user
            }).ToList();

            await _courseQuizUploadWrite.AddRangeAsync(courseUploads);
            await _courseQuizUploadWrite.SaveAsync();
            findQuestion.Video = courseUploads;
        }

        if (model.QuizAnswers != null)
        {
            var newAnswers = new List<CourseQuizAnswer>();
            foreach (var answer in model.QuizAnswers)
            {
                var existingAnswer = findQuestion.CourseQuizAnswers.FirstOrDefault(x => x.Id == answer.Id);
                if (existingAnswer != null)
                {
                    existingAnswer.Title = answer.Title ?? existingAnswer.Title;
                    existingAnswer.IsCorrect = answer.IsCorrect ?? existingAnswer.IsCorrect;
                    existingAnswer.Description = answer.Description ?? existingAnswer.Description;
                }
                else
                {
                    var createAnswer = new CourseQuizAnswer()
                    {
                        Title = answer?.Title,
                        IsCorrect = answer?.IsCorrect,
                        Description = answer?.Description,
                        CourseQuestionId = findQuestion.Id,
                        CourseQuestion = findQuestion
                    };
                    newAnswers.Add(createAnswer);
                }
            }


            var answersToRemove = findQuestion.CourseQuizAnswers
                .Where(existingAnswer => model.QuizAnswers.All(answer => answer.Id != existingAnswer.Id))
                .ToList();

            foreach (var answerToRemove in answersToRemove)
            {
                findQuestion.CourseQuizAnswers.Remove(answerToRemove);
                _courseQuizAnswerWrite.Remove(answerToRemove);
            }

            findQuestion.CourseQuizAnswers.AddRange(newAnswers);
        }


        _courseQuizQuestionWrite.Update(findQuestion);
        await _courseQuizQuestionWrite.SaveAsync();

        return Response<UpdateCourseQuestionCommandResponse>.Success("Course question updated");
    }

    public async Task<Response<CourseTypeOrderCommandResponse>> UpdateCourseTypeOrder(CourseTypeOrderCommandRequest model)
    {
        try
        {
            if (model.AccordionType == SectionAccordionEnum.Item)
            {
                var result = await _courseSectionRead.GetWhere(ux => ux.Id == model.SectionId)
                                                    .Include(x => x.CourseTypes)
                                                    .FirstOrDefaultAsync();

                if (result == null)
                {
                    return Response<CourseTypeOrderCommandResponse>.Fail("Section not found");
                }

                foreach (var item in model.Data)
                {
                    var courseType = result.CourseTypes.FirstOrDefault(ct => ct.Id == item.Id);
                    courseType.Order = model.Data.IndexOf(item);
                }

                _courseSectionWrite.Update(result);
                await _courseSectionWrite.SaveAsync();
            }
            else if (model.AccordionType == SectionAccordionEnum.Chapter)
            {
                foreach (var item in model.Data)
                {
                    var section = await _courseSectionRead.GetWhere(ux => ux.Id == item.Id)
                                                          .FirstOrDefaultAsync();
                    section.Order = model.Data.IndexOf(item);
                    _courseSectionWrite.Update(section);
                    await _courseSectionWrite.SaveAsync();
                }
            }
            else if (model.AccordionType == SectionAccordionEnum.QuizAndCertificate)
            {
                foreach (var item in model.Data)
                {
                    var quiz = await _courseQuizesRead.GetWhere(ux => ux.Id == item.Id).FirstOrDefaultAsync();
                    quiz.Order = model.Data.IndexOf(item);
                    _courseQuizesWrite.Update(quiz);
                    await _courseQuizesWrite.SaveAsync();
                }
            }

            return Response<CourseTypeOrderCommandResponse>.Success(new CourseTypeOrderCommandResponse());
        }
        catch (Exception e)
        {
            return Response<CourseTypeOrderCommandResponse>.Fail(e.Message);
        }
    }


    public async Task<Response<FaqTypeOrderCommandResponse>> UpdateFaqTypeOrder(FaqTypeOrderCommandRequest model)
    {
        if (model.AccordionType == FaqAccordionType.Faq)
        {
            var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
                .Include(x => x.Faqs)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return Response<FaqTypeOrderCommandResponse>.Fail("Course not found");
            }

            foreach (var item in model.Data)
            {
                var faq = result.Faqs.FirstOrDefault(ct => ct.Id == item.Id);
                if (faq == null)
                {
                    return Response<FaqTypeOrderCommandResponse>.Fail("Hatalı F&Q veya Accordion");
                }

                faq.Order = model.Data.IndexOf(item);
            }
            _inclusiveCourseWrite.Update(result);
            await _inclusiveCourseWrite.SaveAsync();
        }
        else if (model.AccordionType == FaqAccordionType.LearningMaterial)
        {
            var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
                .Include(x => x.FaqLearningMaterial)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return Response<FaqTypeOrderCommandResponse>.Fail("Course not found");
            }

            foreach (var item in model.Data)
            {
                var learningMaterial = result.FaqLearningMaterial.FirstOrDefault(ct => ct.Id == item.Id);
                if (learningMaterial == null)
                {
                    return Response<FaqTypeOrderCommandResponse>.Fail("Hatalı Learning Material veya Accordion");
                }
                learningMaterial.Order = model.Data.IndexOf(item);
            }
            _inclusiveCourseWrite.Update(result);
            await _inclusiveCourseWrite.SaveAsync();
        }
        else if (model.AccordionType == FaqAccordionType.CompanyLogo)
        {
            var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
                .Include(x => x.FaqUploadLogo)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return Response<FaqTypeOrderCommandResponse>.Fail("Course not found ");
            }
            foreach (var item in model.Data)
            {
                var uploadLogo = result.FaqUploadLogo.FirstOrDefault(ct => ct.Id == item.Id);
                if (uploadLogo == null)
                {
                    return Response<FaqTypeOrderCommandResponse>.Fail("Hatalı Company Logo veya Accordion");
                }
                uploadLogo.Order = model.Data.IndexOf(item);
            }
            _inclusiveCourseWrite.Update(result);
            await _inclusiveCourseWrite.SaveAsync();

        }
        else if (model.AccordionType == FaqAccordionType.Requirements)
        {
            var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
                .Include(x => x.FaqRequirements)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return Response<FaqTypeOrderCommandResponse>.Fail("Course not found");
            }
            foreach (var item in model.Data)
            {
                var requirements = result.FaqRequirements.FirstOrDefault(ct => ct.Id == item.Id);
                if (requirements == null)
                {
                    return Response<FaqTypeOrderCommandResponse>.Fail("Hatalı Requirements veya Accordion");
                }
                requirements.Order = model.Data.IndexOf(item);
            }
            _inclusiveCourseWrite.Update(result);
            await _inclusiveCourseWrite.SaveAsync();
        }
        else
        {
            return Response<FaqTypeOrderCommandResponse>.Fail("Invalid Accordion Type");
        }

        return Response<FaqTypeOrderCommandResponse>.Success("Sıralama yapıldı.");
    }



    public async Task<Response<UploadFaqCommandResponse>> UploadFaq(UploadFaqCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.Faqs)
            .FirstOrDefaultAsync();

        if (result == null)
        {
            return Response<UploadFaqCommandResponse>.Fail("Course not found");
        }

        if (result.Faqs == null)
        {
            result.Faqs = new List<FaqOption>();
        }
        result.Faqs.Add(new FaqOption
        {
            Order = model.Order,
            LanguageId = model.LanguageId,
            Title = model.Title,
            Answer = model.Answer
        });

        _inclusiveCourseWrite.Update(result);
        await _inclusiveCourseWrite.SaveAsync();
        return Response<UploadFaqCommandResponse>.Success("Faq added");
    }

    public async Task<Response<UploadLearningMaterialCommandResponse>> UploadLearningMaterial(UploadLearningMaterialCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.FaqLearningMaterial)
            .FirstOrDefaultAsync();

        if (result == null)
        {
            return Response<UploadLearningMaterialCommandResponse>.Fail("Course not found");
        }

        if (result?.FaqLearningMaterial == null)
        {
            result.FaqLearningMaterial = new List<FaqLearningMaterial>();
        }
        result.FaqLearningMaterial.Add(new FaqLearningMaterial
        {
            Order = model.Order,
            LanguageId = model.LanguageId,
            Title = model.Title,

        });

        _inclusiveCourseWrite.Update(result);
        await _inclusiveCourseWrite.SaveAsync();
        return Response<UploadLearningMaterialCommandResponse>.Success("Faq added");
    }

    public async Task<Response<UploadCompanyLogoCommandResponse>> UploadCompanyLogo(UploadCompanyLogoCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.FaqUploadLogo)
            .FirstOrDefaultAsync();

        if (result == null)
        {
            return Response<UploadCompanyLogoCommandResponse>.Fail("Course not found");
        }

        if (result.FaqUploadLogo == null)
        {
            result.FaqUploadLogo = new List<FaqUploadLogo>();
        }

        if (model.Image != null && await _fileCheckHelper.CheckImageFormat(model.Image))
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var user = await _servicesHelper.GetUserById(userId);
            var data = await _storageService.UploadAsync("files", model.Image);
            var courseUploads = new FaqUploadLogo
            {
                Order = model.Order,
                FileName = data.fileName,
                Path = data.pathOrContainerName,
                Storage = _storageService.StorageName,
                AppUser = user
            };

            await _faqUploadLogoWrite.AddAsync(courseUploads);
            await _faqUploadLogoWrite.SaveAsync();
            result.FaqUploadLogo.Add(courseUploads);
        }
        _inclusiveCourseWrite.Update(result);
        await _inclusiveCourseWrite.SaveAsync();

        return Response<UploadCompanyLogoCommandResponse>.Success("Company logo added");
    }

    public async Task<Response<UploadRequirementsCommandResponse>> UploadRequirements(UploadRequirementsCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.FaqUploadLogo)
            .FirstOrDefaultAsync();

        if (result == null)
        {
            return Response<UploadRequirementsCommandResponse>.Fail("Course not found");
        }

        if (result.FaqRequirements == null)
        {
            result.FaqRequirements = new List<FaqRequirements>();
        }
        result.FaqRequirements.Add(new FaqRequirements
        {
            Order = model.Order,
            LanguageId = model.LanguageId,
            Title = model.Title,
        });
        _inclusiveCourseWrite.Update(result);
        await _inclusiveCourseWrite.SaveAsync();
        return Response<UploadRequirementsCommandResponse>.Success("Requirements added");
    }


    public async Task<Response<GetBasicInformationCommandResponse>> GetCourseBasicInformation(GetBasicInformationCommandRequest model)
    {
        var result = await _inclusiveCourseRead
            .GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.CourseBasicInformation)
            .Include(x => x.CourseBasicInformation.CoverImage)
            .Include(x => x.CourseBasicInformation.Thumbnail)
            .FirstOrDefaultAsync();
        var response = new GetBasicInformationCommandResponse
        {
            Data = new BasicInformationResponseDto
            {
                Title = result.CourseBasicInformation.Title,
                CourseType = result.CourseBasicInformation.CourseType,
                Language = result.CourseBasicInformation.Language,
                SeoDescription = result.CourseBasicInformation.SeoDescription,
                Thumbnail = result.CourseBasicInformation.Thumbnail.Path,
                CoverImage = result.CourseBasicInformation.CoverImage.Path,
                Description = result.CourseBasicInformation.Description
            }
        };

        return Response<GetBasicInformationCommandResponse>.Success(response);
    }

    public async Task<Response<GetExtraInformationCommandResponse>> GetExtraInformation(GetExtraInformationCommandRequest model)
    {
        var extraInfo = await _inclusiveCourseRead.GetWhere(c => c.Id == model.CourseId)
            .Include(x => x.CourseExtraInformation)
            .ThenInclude(x=>x.CourseSubLanguages)
            .FirstOrDefaultAsync();

        var response = new GetExtraInformationCommandResponse
        {
            Data = new ExtraInformationResponseDto
            {
                CategoryId = extraInfo.CourseExtraInformation.CategoryId,
                CourseLevel = extraInfo.CourseExtraInformation.CourseLevel,
                Duration = extraInfo.CourseExtraInformation.Duration,
                IsCourseForm = extraInfo.CourseExtraInformation.IsCourseForm,
                IsDownloadable = extraInfo.CourseExtraInformation.IsDownloadable,
                IsCertificate = extraInfo.CourseExtraInformation.IsCertificate,
                IsPartnered = extraInfo.CourseExtraInformation.IsPartnered,
                IsSupport = extraInfo.CourseExtraInformation.IsSupport,
                Tag = extraInfo.CourseExtraInformation.Tag.Split(',')
                    .Select(ux => new courseExtraInformationTags { Tag = ux }).ToList(),
                CourseSubLanguages = extraInfo.CourseExtraInformation?.CourseSubLanguages.Select(x => new SubTitleLanguageId()
                {
                    language = x.LanguageId
                 }).ToList()
            }
        };

        return Response<GetExtraInformationCommandResponse>.Success(response);
    }

    public async Task<Response<GetPricingCommandResponse>> GetPricing(GetPricingCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(ux => ux.CoursePricing)
            .ThenInclude(ux => ux.NewCoursePricingPlan)
            .FirstOrDefaultAsync();

        var response = new GetPricingCommandResponse
        {
            Price = result.CoursePricing.Price,
            IsFree = result.CoursePricing.IsFree,
            PricingPlan = result.CoursePricing.NewCoursePricingPlan.Select(ux => new NewCoursePricingPlanRequestDto
            {
                Title = ux.Title,
                Discount = ux.Discount,
                Capacity = ux.Capacity,
                Price = ux.Price,
                StartDate = ux.StartDate,
                EndDate = ux.EndDate,
                Language = ux.Language
            }).ToList()
        };

        return Response<GetPricingCommandResponse>.Success(response);
    }

    public async Task<Response<GetContentCommandResponse>> GetContent(GetContentCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.Sections)
                .ThenInclude(x => x.CourseTypes)
                    .ThenInclude(x => x.CourseSources)
                        .ThenInclude(x => x.CourseUpload)
            .Include(x => x.Sections)
                .ThenInclude(x => x.CourseTypes)
                    .ThenInclude(ux => ux.CourseQuizzes)
                        .ThenInclude(ux => ux.CourseQuestions)
                            .ThenInclude(ux => ux.Image)
            .Include(x => x.Sections)
                .ThenInclude(x => x.CourseTypes)
                    .ThenInclude(ux => ux.CourseQuizzes)
                        .ThenInclude(ux => ux.CourseQuestions)
                            .ThenInclude(ux => ux.Video)
            .Include(x => x.Sections)
                .ThenInclude(x => x.CourseTypes)
                    .ThenInclude(ux => ux.CourseQuizzes)
                        .ThenInclude(ux => ux.CourseQuestions)
                            .ThenInclude(ux => ux.CourseQuizAnswers)
            .FirstOrDefaultAsync();

        var response = new GetContentCommandResponse
        {
            Data = result.Sections.OrderBy(x => x.Order).Select(s => new ContentSectionResponseDto
            {
                Id = s.Id,
                Title = s.Title,
                LanguageId = s.LanguageId,
                IsActive = s.IsActive,
                PassAllParts = s.PassAllParts,
                Order = s.Order,
                CourseTypes = s.CourseTypes.OrderBy(x => x.Order).ThenBy(x => x.CreatedDate).Select(ct => new ContentTypeResponseDto
                {
                    Id = ct.Id,
                    Order = ct.Order,
                    CourseSources = ct.CourseSources != null ? new ContentSourceResponseDto
                    {
                        LanguageId = ct.CourseSources.LanguageId,
                        Title = ct.CourseSources.Title,
                        IsFree = ct.CourseSources.IsFree,
                        Description = ct.CourseSources.Description,
                        IsActive = ct.CourseSources.IsActive,
                        Link = ct.CourseSources.Link,
                        Source = ct.CourseSources.Source,
                        FileType = ct.CourseSources.FileType,
                        CourseSectionsId = ct.CourseSources.CourseSectionsId,
                        ContentUpload = ct.CourseSources.CourseUpload.Select(cu => new ContentUploadResponseDto
                        {
                            FileName = cu.FileName,
                            Path = cu.Path
                        }).ToList()
                    } : null,
                    CourseQuizzes = ct.CourseQuizzes != null ? new ContentQuizResponseDto
                    {
                        Id = ct.CourseQuizzes.Id,
                        CourseSectionsId = ct.CourseQuizzes.CourseSections.Id,
                        Language = ct.CourseQuizzes.Language,
                        Title = ct.CourseQuizzes.Title,
                        Time = ct.CourseQuizzes.Time,
                        Attempts = ct.CourseQuizzes.Attempts,
                        PassingScore = ct.CourseQuizzes.PassingScore,
                        ExpiryDate = ct.CourseQuizzes.ExpiryDate,
                        LimitedQuestion = ct.CourseQuizzes.LimitedQuestion,
                        QuestionCount = ct.CourseQuizzes.QuestionCount,
                        RandomizeQuestion = ct.CourseQuizzes.RandomizeQuestion,
                        Certificate = ct.CourseQuizzes.Certificate,
                        IsActive = ct.CourseQuizzes.IsActive,
                        CourseQuestions = ct.CourseQuizzes.CourseQuestions.Select(cqq => new ContentQuizQuestionsResponseDto
                        {
                            LanguageId = cqq.LanguageId,
                            Title = cqq.Title,
                            Grade = cqq.Grade,
                            QuestionType = cqq.QuestionType,
                            Video = cqq.Video?.Select(v => new ContentUploadResponseDto
                            {
                                FileName = v.FileName,
                                Path = v.Path
                            }).ToList(),
                            Image = cqq.Image != null ? new ContentUploadResponseDto
                            {
                                FileName = cqq.Image.FileName,
                                Path = cqq.Image.Path
                            } : null,
                            CourseQuizAnswers = cqq.CourseQuizAnswers.Select(cqa => new ContentQuizAnswerResponseDto
                            {
                                CourseQuestionId = cqa.CourseQuestionId,
                                Title = cqa.Title,
                                IsCorrect = cqa.IsCorrect,
                                Description = cqa.Description
                            }).ToList()
                        }).ToList()
                    } : null,
                }).ToList()
            }).ToList()
        };

        return Response<GetContentCommandResponse>.Success(response);
    }

    public async Task<Response<GetQuizAndCertificationCommandResponse>> GetQuizAndCertification(GetQuizAndCertificationCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
             .Include(x => x.Sections)
                 .ThenInclude(x => x.CourseTypes)
                     .ThenInclude(x => x.CourseQuizzes)
                         .ThenInclude(x => x.CourseQuestions)
                             .ThenInclude(x => x.CourseQuizAnswers)
             .FirstOrDefaultAsync();

        var response = result.Sections.SelectMany(s =>
        {
            return s.CourseTypes.OrderBy(x => x.Order).SelectMany(ct =>
            {
                if (ct.CourseQuizzes != null)
                {
                    return new List<ContentQuizResponseDto>
            {
                new ContentQuizResponseDto
                {
                    Id = ct.CourseQuizzes.Id,
                    Order = ct.Order,
                    CourseSectionsId = ct.CourseQuizzes.CourseSections.Id,
                    Language = ct.CourseQuizzes.Language,
                    Title = ct.CourseQuizzes.Title,
                    Time = ct.CourseQuizzes.Time,
                    Attempts = ct.CourseQuizzes.Attempts,
                    PassingScore = ct.CourseQuizzes.PassingScore,
                    ExpiryDate = ct.CourseQuizzes.ExpiryDate,
                    LimitedQuestion = ct.CourseQuizzes.LimitedQuestion,
                    QuestionCount = ct.CourseQuizzes.QuestionCount,
                    RandomizeQuestion = ct.CourseQuizzes.RandomizeQuestion,
                    Certificate = ct.CourseQuizzes.Certificate,
                    IsActive = ct.CourseQuizzes.IsActive,
                    CourseQuestions = ct.CourseQuizzes.CourseQuestions.Select(cqq => new ContentQuizQuestionsResponseDto
                    {
                        LanguageId = cqq.LanguageId,
                        Title = cqq.Title,
                        Grade = cqq.Grade,
                        QuestionType = cqq.QuestionType,
                        Video = cqq.Video?.Select(v => new ContentUploadResponseDto
                        {
                            FileName = v.FileName,
                            Path = v.Path
                        }).ToList(),
                        Image = cqq.Image != null ? new ContentUploadResponseDto
                        {
                            FileName = cqq.Image.FileName,
                            Path = cqq.Image.Path
                        } : null,
                        CourseQuizAnswers = cqq.CourseQuizAnswers.Select(cqa => new ContentQuizAnswerResponseDto
                        {
                            CourseQuestionId = cqa.CourseQuestionId,
                            Title = cqa.Title,
                            IsCorrect = cqa.IsCorrect,
                            Description = cqa.Description
                        }).ToList()
                    }).ToList()
                }
            };
                }
                else
                {
                    return new List<ContentQuizResponseDto>();
                }
            });
        }).ToList();

        return Response<GetQuizAndCertificationCommandResponse>.Success(new GetQuizAndCertificationCommandResponse { Data = response });
    }

    public async Task<Response<GetCourseLearningPageCommandResponse>> GetCourseLearningPage(GetCourseLearningPageCommandRequest model)
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var course = await _inclusiveCourseRead.GetByIdAsync(model.CourseId.ToString());

        if (userId == null || course == null)
        {
            return Response<GetCourseLearningPageCommandResponse>.Fail("Course not found");
        }

        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.Sections)
                .ThenInclude(x => x.CourseTypes)
                    .ThenInclude(x => x.CourseSources)
            .Include(x => x.Sections)
                .ThenInclude(x => x.CourseTypes)
                    .ThenInclude(ux => ux.CourseQuizzes)
            .ThenInclude(x => x.CourseQuestions)
            .FirstOrDefaultAsync();

        var response = new GetCourseLearningPageCommandResponse
        {
            Data = result.Sections.OrderBy(x => x.Order).Select(s => new LearningPageSectionResponseDto
            {
                Id = s.Id,
                Title = s.Title,
                Order = s.Order,
                SectionCount = s.CourseTypes.Count,
                CourseTypes = s.CourseTypes.OrderBy(x => x.Order).ThenBy(x => x.CreatedDate).Select(ct => new LearningPageContentTypeResponseDto
                {
                    Id = ct.Id,
                    Order = ct.Order,
                    contentSource = ct.CourseSources != null ? new LearningPageContentSourceResponseDto
                    {
                        Id = ct.CourseSources.Id,
                        Title = ct.CourseSources.Title,
                        Description = ct.CourseSources.Description,
                        FileType = ct.CourseSources.FileType,
                    }:null,
                    contetnQuizzes = ct.CourseQuizzes != null ? new LearningPageContentQuizzesResponseDto()
                    {
                        Id = ct.CourseQuizzes.Id,
                        Title = ct.CourseQuizzes.Title,
                        QuestionCount = ct.CourseQuizzes.CourseQuestions.Count,
                        Minutes = ct.CourseQuizzes.Time,
                    } : null,
                }).ToList()
            }).ToList()
        };

        return Response<GetCourseLearningPageCommandResponse>.Success(response);
    }

    public async Task<Response<GetCoursesPageCommandResponse>> GetCoursesPage(GetCoursesPageCommandRequest model)
    {
        var currentDate = DateTime.UtcNow;
        var showPage = 10;

        IQueryable<InclusiveCourse> query = _inclusiveCourseRead.GetWhere(ux => ux.isActive && ux.Published)
            .Include(ux => ux.CourseBasicInformation)
            .ThenInclude(ux => ux.CoverImage)
            .ThenInclude(x => x.AppUser)
            .ThenInclude(x => x.UserProfileImage)
            .Include(ux => ux.CourseExtraInformation)
            .ThenInclude(ux => ux.CourseSubLanguages)
            .Include(ux => ux.CourseExtraInformation)
            .ThenInclude(ux => ux.Category)
            .Include(x => x.CoursePricing)
            .ThenInclude(x => x.NewCoursePricingPlan);

        query = query.Where(ux =>
            (model.CategoryId == null || ux.CourseExtraInformation.CategoryId == model.CategoryId) &&
            (model.IsFree == null || (model.IsFree == true && ux.CoursePricing.IsFree)) &&
            (model.CourseLevel == null || ux.CourseExtraInformation.CourseLevel == model.CourseLevel) &&
            (model.IsDiscounted == null || (model.IsDiscounted == true &&
                                            ux.CoursePricing.NewCoursePricingPlan.Any(x =>
                                                x.StartDate <= currentDate && x.EndDate >= currentDate && x.Capacity > 0 && x.Discount > 0))) &&
            (model.IsDownloadable == null || (model.IsDownloadable == true && ux.CourseExtraInformation.IsDownloadable)) &&
            (model.CourseType == null || ux.CourseBasicInformation.CourseType == model.CourseType)
        );



        switch (model.SortOrder)
        {
            case CourseSortOrder.HighPrice:
                query = query.OrderByDescending(ux => ux.CoursePricing.NewCoursePricingPlan
                    .Where(x => x.StartDate <= currentDate && x.EndDate >= currentDate && x.Capacity > 0)
                    .OrderByDescending(x => x.Discount)
                    .Select(x => x.Price)
                    .FirstOrDefault());
                break;
            case CourseSortOrder.LowPrice:
                query = query.OrderBy(ux => ux.CoursePricing.NewCoursePricingPlan
                    .Where(x => x.StartDate <= currentDate && x.EndDate >= currentDate && x.Capacity > 0)
                    .OrderByDescending(x => x.Discount)
                    .Select(x => x.Price)
                    .FirstOrDefault());
                break;
            case CourseSortOrder.ReviewCount:
               // query = query.OrderByDescending(ux => ux.ReviewsCount); // ReviewsCount, varsa
                break;
            case CourseSortOrder.Newest:
                query = query.OrderByDescending(ux => ux.CreatedDate);
                break;
            case CourseSortOrder.Oldest:
                query = query.OrderBy(ux => ux.CreatedDate);
                break;
            case CourseSortOrder.All:
            default: 
                query = query.OrderBy(ux => ux.Id); 
                break;
        }

        var result = await query
            .Skip((model.Page - 1) * showPage)
            .Take(showPage)
            .Select(ux => new
            {
                Course = ux,
                ApplicablePrice = ux.CoursePricing.NewCoursePricingPlan
                    .Where(x => x.StartDate <= currentDate && x.EndDate >= currentDate && x.Capacity > 0)
                    .OrderByDescending(x => x.Discount)
                    .FirstOrDefault()
            })
            .ToListAsync();



        var response = new GetCoursesPageCommandResponse()
        {
            CourseCount = result.Count(),
            Data = result.Select(item =>
            {
                var ux = item.Course;
                var coursePrice = item.ApplicablePrice != null ? item.ApplicablePrice.Price : (ux.CoursePricing?.Price ?? 0);
                var Discount = item.ApplicablePrice != null ? item.ApplicablePrice.Discount : 0;
                var isDiscounted = Discount > 0;
                var isFree = coursePrice == 0;

                var durationInMinutes = ux.CourseExtraInformation.Duration;
                TimeSpan duration = TimeSpan.FromMinutes(durationInMinutes);
                var hours = duration.Hours;
                var minutes = duration.Minutes;
                string courseTime = $"{hours}:{minutes:D2}";

                return new GetAllCoursesPage
                {
                    Id = ux.Id,
                    CategoryId = ux.CourseExtraInformation.CategoryId,
                    CategoryName = ux.CourseExtraInformation.Category.Name,
                    Language = ux.CourseBasicInformation.Language,
                    CourseLevel = ux.CourseExtraInformation.CourseLevel,
                    CoverImage = ux.CourseBasicInformation.CoverImage?.Path,
                    CourseType = ux.CourseBasicInformation.CourseType,
                    ModeratorName = ux.CourseBasicInformation.CoverImage?.AppUser?.UserName,
                    ModeratorImage = ux.CourseBasicInformation.CoverImage?.AppUser?.UserProfileImage.FirstOrDefault()?.Path,
                    ReviewsCount = 0,  // You might want to replace these with actual data
                    CourseTime = courseTime,  // You might want to replace these with actual data
                    CreatedDate = ux.CreatedDate.ToString("d MMM yyyy"),
                    CoursePrice = coursePrice,
                    IsFree = isFree,
                    Discount = Discount,
                    IsDiscounted = isDiscounted,
                    IsDownloadable = ux.CourseExtraInformation.IsDownloadable,
                    CourseTitle = ux.CourseBasicInformation.Title,
                    CourseSubLanguages = ux.CourseExtraInformation.CourseSubLanguages != null ?
                        ux.CourseExtraInformation.CourseSubLanguages.Select(x => new SubTitleLanguageId
                        {
                            language = x.LanguageId
                        }).ToList() :
                        new List<SubTitleLanguageId>()
                };
            }).ToList()
        };

        return Response<GetCoursesPageCommandResponse>.Success(response);
    }

    public async Task<Response<GetCourseDetailPageCommandResponse>> GetCourseDetailPage(GetCourseDetailPageCommandRequest model)
    {
        var currentDate = DateTime.UtcNow;

        IQueryable<InclusiveCourse> query =  _inclusiveCourseRead.GetWhere(ux => ux.isActive && ux.Published && ux.Id == model.CourseId)
            .Include(ux => ux.CourseBasicInformation)
                .ThenInclude(ux => ux.CoverImage)
            .Include(ux=>ux.CourseBasicInformation)
                .ThenInclude(ux=>ux.Thumbnail)
                    .ThenInclude(x => x.AppUser)
                        .ThenInclude(x => x.UserProfileImage)
            .Include(ux => ux.CourseExtraInformation)
                .ThenInclude(ux => ux.CourseSubLanguages)
            .Include(ux => ux.CourseExtraInformation)
                .ThenInclude(ux => ux.Category)
            .Include(x => x.CoursePricing)
                .ThenInclude(x => x.NewCoursePricingPlan)
            .Include(x => x.Sections)
            .ThenInclude(x => x.CourseTypes)
                    .ThenInclude(x => x.CourseSources)
            .ThenInclude(x => x.CourseUpload)
            .Include(x => x.Sections)
                .ThenInclude(ux=>ux.CourseTypes)
                    .ThenInclude(ux=>ux.CourseQuizzes)
                        .ThenInclude(ux=>ux.CourseQuestions)
            .Include(ux=>ux.Faqs)
            .Include(ux=>ux.FaqLearningMaterial)
            .Include(ux=>ux.FaqRequirements)
            .Include(ux=>ux.FaqUploadLogo)
            .Include(ux=>ux.AppUser)
            .Include(x=>x.CourseExtraInformation)
            .ThenInclude(x=>x.Partner);

        var result = await query.Select(ux => new
            {
                Course = ux,
                ApplicablePrice = ux.CoursePricing.NewCoursePricingPlan
                    .Where(x => x.StartDate <= currentDate && x.EndDate >= currentDate && x.Capacity > 0)
                    .OrderByDescending(x => x.Discount)
                    .FirstOrDefault()
            })
            .FirstOrDefaultAsync();

        var course = result.Course;
        var coursePrice = result.ApplicablePrice != null ? result.ApplicablePrice.Price : (course.CoursePricing?.Price ?? null);
  

        var durationInMinutes = course.CourseExtraInformation.Duration;
        TimeSpan duration = TimeSpan.FromMinutes(durationInMinutes);
        var hours = duration.Hours;
        var minutes = duration.Minutes;
        string courseTime = $"{hours}:{minutes:D2}";

        var CourseInformation = new CourseInformationResponseDto()
        {
            Id = course.Id,
            CategoryId = course.CourseExtraInformation.CategoryId,
            CategoryName = course.CourseExtraInformation.Category.Name,
            Language = course.CourseBasicInformation.Language,
            CourseTitle = course.CourseBasicInformation.Title,
            CourseRating = 0, // You might want to replace these with actual data
            CourseLevel = course.CourseExtraInformation.CourseLevel,
            CourseReviewsCount = 0, // You might want to replace these with actual data
            CourseDescription = course.CourseBasicInformation.Description,
            LearningMaterials = course.FaqLearningMaterial.Select(x => x.Title).ToList(),
            CourseLogo = course.FaqUploadLogo.Select(x => x.Path).ToList(),
            CourseRequirements = course.FaqRequirements.Select(x => x.Title).ToList(),
            CourseFaq = course.Faqs.Select(x => new Faq
            {
                Title = x.Title,
                Description = x.Answer
            }).ToList(),
            Price = course.CoursePricing.Price,
            DiscountedPrice =coursePrice,
            Discount = result.ApplicablePrice.Discount,
            DiscountEndDate = result.ApplicablePrice.EndDate,
            IsFree = coursePrice == 0,
            Tags = course.CourseExtraInformation.Tag.Split(',').ToList(),
        };

        var CourseIncludes = new CourseIncludesResponseDto()
        {
            IsCertificate = course.CourseExtraInformation.IsCertificate,
            IsDownloadable = course.CourseExtraInformation.IsDownloadable,
            IsSupport = course.CourseExtraInformation.IsSupport,
            QuizzesCount = course.Sections.SelectMany(x => x.CourseTypes).Select(x => x.CourseQuizzes).Count(),
        };

        var CourseSpecifications = new CourseSpecificationsResponseDto()
        {
            Capacity = "Unlimited",
            CreatedDate = course.CreatedDate.ToString("d MMM yyyy"),
            Duration = courseTime,
            StudentCount = 0, // You might want to replace these with actual data
            DownloadableFileCount = 0 // You might want to replace these with actual data
        };

        var Moderator = new List<ModeratorInformation>();

        if (course.AppUser != null)
        {
            Moderator.Add(new ModeratorInformation
            {
                Name = course.AppUser.UserName ?? "",
                ProfilePicture = course.AppUser.UserProfileImage.FirstOrDefault()?.Path ?? "",
                JobTitle = course.AppUser.UserAccountAbout?.JobTitle ?? "", 
                Rating = 0, // You might want to replace these with actual data
                LinkedIn = "", // You might want to replace these with actual data
                Github = "" // You might want to replace these with actual data
            });
        }

        if (course.CourseExtraInformation?.Partner != null)
        {
            Moderator.Add(new ModeratorInformation()
            {
                Name = course.CourseExtraInformation.Partner.UserName ?? "",
                ProfilePicture = course.CourseExtraInformation.Partner.UserProfileImage.FirstOrDefault()?.Path ?? "", 
                JobTitle = course.CourseExtraInformation.Partner.UserAccountAbout?.JobTitle ?? "", 
                Rating = 0, // You might want to replace these with actual data
                LinkedIn = "", // You might want to replace these with actual data
                Github = "" // You might want to replace these with actual data
            });
        }

        var result2 = course.Sections.SelectMany(x => x.CourseTypes).Select(x => x.CourseSources);
        var Content = course.Sections.Select(s => new CourseContentResponseDto()
        {
            Title = s.Title,
            CourseContentDetails = s.CourseTypes.OrderBy(x=>x.Order).ThenBy(x=>x.CreatedDate).Select(x=> new CourseContentDetailResponseDto()
            {
                ContentSourceType = x.CourseSources != null ? new ContentSourceTypeRequestDto()
                {
                    Title = x.CourseSources.Title,
                    Description = x.CourseSources.Description,
                    IsFree = x.CourseSources.IsFree,
                    ContentUploads = x.CourseSources.IsFree && x.CourseSources.CourseUpload != null && x.CourseSources.CourseUpload.Any()
                        ? x.CourseSources.CourseUpload.Select(cu => new ContentUploadResponseDto()
                        {
                            FileName = cu.FileName,
                            Path = cu.Path
                        }).ToList()
                        : (string.IsNullOrEmpty(x.CourseSources.Link) ? null : new List<ContentUploadResponseDto>
                        {
                            new ContentUploadResponseDto
                            {
                                // Here you can decide whether to use Link for FileName, Path, or both
                                FileName = "",
                                Path = x.CourseSources.Link // or another appropriate property
                            }
                        })
                } : null,

                ContentQuizzesType = x.CourseQuizzes !=null ? new ContentQuizzesTypeResponseDto()
                {
                    AttemptCount = x.CourseQuizzes.Attempts,
                    Duration = x.CourseQuizzes.Time,
                    Grade = x.CourseQuizzes.PassingScore,
                    QuestionCount = x.CourseQuizzes.CourseQuestions.Count,
                }:null
            }).ToList()

        }).ToList();

        

        var response = new GetCourseDetailPageCommandResponse()
        {
            Data = new GetCourseDetailPage()
            {
               CourseInformation = CourseInformation,
               CourseIncludes = CourseIncludes,
               CourseSpecifications = CourseSpecifications,
               CourseModeratorInformation = Moderator,
               CourseContentDetail = Content
            }
        };



        return Response<GetCourseDetailPageCommandResponse>.Success(response);
    }


    public async Task<Response<DeleteCourseSectionCommandResponse>> DeleteCourseSection(DeleteCourseSectionCommandRequest model)
    {
        await _courseSectionWrite.RemoveAsync(model.SectionId.ToString());
        await _courseSectionWrite.SaveAsync();
        return Response<DeleteCourseSectionCommandResponse>.Success("Course section deleted");
    }

    public async Task<Response<DeleteCourseQuestionCommandResponse>> DeleteCourseQuestion(DeleteCourseQuestionCommandRequest model)
    {
        var result = await _courseQuizQuestionRead.GetWhere(x => x.Id == model.questionId)
            .Include(x => x.Image)
                       .Include(x => x.Video)
                       .Include(x => x.CourseQuizAnswers)
                       .FirstOrDefaultAsync();

        if (result == null)
        {
            return Response<DeleteCourseQuestionCommandResponse>.Fail("Question not found");
        }

        if (result.Image != null)
        {
            await _storageService.DeleteAsync(result.Image.Path.Split(Path.DirectorySeparatorChar)[0], result.Image.FileName);
            _courseQuizUploadWrite.Remove(result.Image);
        }

        if (result.Video != null)
        {
            foreach (var quizVideo in result.Video)
            {
                await _storageService.DeleteAsync(quizVideo.Path.Split(Path.DirectorySeparatorChar)[0], quizVideo.FileName);
                _courseQuizUploadWrite.Remove(quizVideo);
            }

        }

        foreach (var answer in result.CourseQuizAnswers)
        {
            _courseQuizAnswerWrite.Remove(answer);
        }

        _courseQuizQuestionWrite.Remove(result);
        await _courseQuizQuestionWrite.SaveAsync();

        return Response<DeleteCourseQuestionCommandResponse>.Success("Course question deleted");
    }

    public async Task<Response<DeleteFaqCommandResponse>> DeleteFaqOption(DeleteFaqCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
                       .Include(x => x.Faqs)
                       .FirstOrDefaultAsync();

        if (result == null)
        {
            return Response<DeleteFaqCommandResponse>.Fail("Course not found");
        }

        var faq = result.Faqs.FirstOrDefault(f => f.Id == model.FaqId);
        if (faq == null)
        {
            return Response<DeleteFaqCommandResponse>.Fail("Faq not found");
        }
        await _faqOptionWrite.RemoveAsync(faq.Id.ToString());
        await _faqOptionWrite.SaveAsync();
        return Response<DeleteFaqCommandResponse>.Success("Faq deleted");
    }

    public async Task<Response<DeleteRequirementsCommandResponse>> DeleteRequirements(DeleteRequirementsCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.FaqRequirements).FirstOrDefaultAsync();
        if (result == null)
        {
            return Response<DeleteRequirementsCommandResponse>.Fail("Course not found");
        }

        var requirements = result.FaqRequirements.FirstOrDefault(f => f.Id == model.Id);
        if (requirements == null)
        {
            return Response<DeleteRequirementsCommandResponse>.Fail("Requirements not found");
        }
        await _faqRequirementsWrite.RemoveAsync(requirements.Id.ToString());
        await _faqRequirementsWrite.SaveAsync();
        return Response<DeleteRequirementsCommandResponse>.Success("Requirements deleted");
    }

    public async Task<Response<DeleteCompanyLogoCommandResponse>> DeleteCompanyLogo(DeleteCompanyLogoCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(ux => ux.Id == model.CourseId)
            .Include(x => x.FaqUploadLogo).FirstOrDefaultAsync();

        if (result == null)
        {
            return Response<DeleteCompanyLogoCommandResponse>.Fail("Course not found");
        }

        var logo = result.FaqUploadLogo.FirstOrDefault(f => f.Id == model.Id);
        if (logo == null)
        {
            return Response<DeleteCompanyLogoCommandResponse>.Fail("Logo not found");
        }
        await _storageService.DeleteAsync(logo.Path.Split(Path.DirectorySeparatorChar)[0], logo.FileName);
        await _faqUploadLogoWrite.RemoveAsync(logo.Id.ToString());
        await _faqUploadLogoWrite.SaveAsync();
        return Response<DeleteCompanyLogoCommandResponse>.Success("Company logo deleted");
    }

    public async Task<Response<DeleteFaqLearningMaterialCommandResponse>> DeleteFaqLearningMaterial(DeleteFaqLearningMaterialCommandRequest model)
    {
        var result = await _inclusiveCourseRead.GetWhere(x => x.Id == model.CourseId)
            .Include(x => x.FaqLearningMaterial)
            .FirstOrDefaultAsync();
        if (result == null)
        {
            return Response<DeleteFaqLearningMaterialCommandResponse>.Fail("Course not found");
        }

        var material = result.FaqLearningMaterial.FirstOrDefault(f => f.Id == model.Id);
        if (material == null)
        {
            return Response<DeleteFaqLearningMaterialCommandResponse>.Fail("Learning material not found");
        }
        await _faqLearningMaterialWrite.RemoveAsync(material.Id.ToString());
        await _faqLearningMaterialWrite.SaveAsync();
        return Response<DeleteFaqLearningMaterialCommandResponse>.Success("Learning material deleted");
    }


    private async Task<CourseQuizUpload> UpdateQuizQuestionImage(IFormFile image, AppUser user, CourseQuestions question)
    {
        var questionPhoto = await _courseQuizQuestionRead?.GetWhere(ux => ux.Id == question.Id)
            .Include(x => x.Image)
            .SingleOrDefaultAsync();


        if (questionPhoto == null)
        {
            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);
            question.Image = new CourseQuizUpload();
            question.Image.FileName = fileName;
            question.Image.Path = pathOrContainerName;
            question.Image.Storage = _storageService.StorageName;
            question.Image.AppUser = user;

            await _courseQuizUploadWrite.AddAsync(question.Image);
            await _courseQuizUploadWrite.SaveAsync();
            return question.Image;
        }
        else
        {
            await _storageService.DeleteAsync(questionPhoto.Image.Path.Split(Path.DirectorySeparatorChar)[0], questionPhoto.Image.FileName);
            var (fileName, pathOrContainerName) = await _storageService.UploadAsync("files", image);
            questionPhoto.Image.FileName = fileName;
            questionPhoto.Image.Path = pathOrContainerName;
            _courseQuizUploadWrite.Update(question.Image);
            await _courseQuizUploadWrite.SaveAsync();
            return questionPhoto.Image;
        }
    }

    private async Task<InclusiveCourse> GetInclusiveCourse(Guid courseId)
    {
        return await _inclusiveCourseRead.GetWhere(c => c.Id == courseId)
            .Include(x => x.CourseBasicInformation)
            .Include(x => x.CourseExtraInformation)
            .Include(x => x.CoursePricing)
            .ThenInclude(x => x.NewCoursePricingPlan)
            .Include(x => x.Sections)
            .ThenInclude(x => x.CourseTypes)
            .ThenInclude(x => x.CourseSources)
            .ThenInclude(x => x.CourseUpload)
            .FirstOrDefaultAsync();
    }
}