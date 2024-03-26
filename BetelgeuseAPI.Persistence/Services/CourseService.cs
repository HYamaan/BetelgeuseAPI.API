using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Storage;
using BetelgeuseAPI.Application.Features.Commands.Course.Delete.DeleteCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.BasicInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseExtraInformation;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CoursePricing;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSections;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseSource;
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
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.UploadCourseQuiz;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseSection.UpdateCourseSection;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseQuizes;
using BetelgeuseAPI.Application.Repositories.Course.CourseExtraInformation;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuiz;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuizAnswer;
using BetelgeuseAPI.Application.Repositories.FileContent.CourseQuizQuestionVideo;
using BetelgeuseAPI.Domain.Entities.Course.Content.Quiz;
using BetelgeuseAPI.Domain.Entities.File.Quiz;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.CourseQuestion.UpdateCourseQuestion;
using BetelgeuseAPI.Application.Features.Commands.Course.CourseQuiz.DeleteCourseQuestion;
using BetelgeuseAPI.Application.Features.Queries.Course.GetBasicInformation;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuestion;
using BetelgeuseAPI.Application.Repositories.Course.CourseQuizUpload;
using BetelgeuseAPI.Domain.Auth;
using Microsoft.AspNetCore.Http;
using BetelgeuseAPI.Application.DTOs.Response.Course;

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

    private readonly IImageService<CourseThumbnail, ICourseThumbnailReadRepository, ICourseThumbnailWriteRepository> _courseThumbnailService;
    public readonly IImageService<CourseCoverImage, ICourseCoverImageReadRepository, ICourseCoverImageWriteRepository> _courseCoverImageService;




    public CourseService(IServicesHelper servicesHelper,
        IStorageService storageService,
        ICourseBasicInformationReadRepository courseBasicInformationRead,
        ICourseBasicInformationWriteRepository courseBasicInformationWrite,
        IInclusiveCourseReadRepository inclusiveCourseRead, IInclusiveCourseWriteRepository inclusiveCourseWrite,
        IImageService<CourseThumbnail, ICourseThumbnailReadRepository, ICourseThumbnailWriteRepository> courseThumbnailService,
        IImageService<CourseCoverImage, ICourseCoverImageReadRepository, ICourseCoverImageWriteRepository> courseCoverImageService,
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
        ICourseExtraInformationReadRepository courseExtraInformationRead, ICourseQuestionWriteRepository courseQuizQuestionWrite, ICourseQuestionReadRepository courseQuizQuestionRead,
        ICourseQuizUploadReadRepository courseQuizUploadRead, ICourseQuizUploadWriteRepository courseQuizUploadWrite)
    {
        _servicesHelper = servicesHelper;
        _courseBasicInformationRead = courseBasicInformationRead;
        _courseBasicInformationWrite = courseBasicInformationWrite;
        _inclusiveCourseRead = inclusiveCourseRead;
        _inclusiveCourseWrite = inclusiveCourseWrite;
        _courseThumbnailService = courseThumbnailService;
        _courseCoverImageService = courseCoverImageService;
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
                    .Include(x => x.CourseBasicInformation).FirstOrDefaultAsync();
                if (result != null) inclusiveCourse = result;
                defaultValue = true;
            }



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
              .Include(x => x.CourseExtraInformation).FirstOrDefaultAsync();

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
            courseExtraInformation.IsSupport = model.IsSupport;
            courseExtraInformation.IsDownloadable = model.IsDownloadable;
            courseExtraInformation.IsPartnered = model.IsPartnered;
            courseExtraInformation.Tag = model.Tag;
            courseExtraInformation.CourseLevel = model.CourseLevel;

            if (model.CourseSubLanguages != null && model.CourseSubLanguages.Any())
            {
                courseExtraInformation.CourseSubLanguage = string.Join(",",
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
        var inclusiveCourse = await GetInclusiveCourse(model.CourseId);

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
            Title = model.Title,
            LanguageId = model.LanguageId,
            IsActive = model.IsActive,
            IsFree = model.IsFree,
            Description = model.Description,
            Source = model.Source,
            FileType = model.FileType
        };

        if (model.Source == CourseUploadSourceType.Upload || model.Source == CourseUploadSourceType.AmazonS3)
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var user = await _servicesHelper.GetUserById(userId);
            if (model.FileType == CourseUploadFileType.Video && await _fileCheckHelper.CheckVideoFormat(model.uploadFile))
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
            else if ((model.FileType == CourseUploadFileType.Pdf && await _fileCheckHelper.CheckPdfFormat(model.uploadFile)) ||
                     (model.FileType == CourseUploadFileType.PowerPoint && await _fileCheckHelper.CheckPPTFormat(model.uploadFile)) ||
                     (model.FileType == CourseUploadFileType.Image && await _fileCheckHelper.CheckImageFormat(model.uploadFile))
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



        section.CourseSources ??= new List<CourseSource>();
        section.CourseSources.Add(newCourseSource);

        _inclusiveCourseWrite.Update(inclusiveCourse);
        await _inclusiveCourseWrite.SaveAsync();

        return Response<CourseSourceCommandResponse>.Success("Course source added");
    }

    public async Task<Response<CourseQuizCommandResponse>> AddCourseQuiz(CourseQuizCommandRequest model)
    {

        var findSection = await _courseSectionRead.GetByIdAsync(model.SectionId.ToString());

        if (findSection == null)
        {
            return Response<CourseQuizCommandResponse>.Fail("Section not found");
        }

        var newQuiz = new CourseQuiz()
        {
            Attempts = model?.Attempts,
            Language = model.Language,
            Title = model.Title,
            Time = model?.Time,
            PassingScore = model.PassingScore,
            ExpiryDate = model?.ExpiryDate,
            LimitedQuestion = model.LimitedQuestion,
            RandomizeQuestion = model.RandomizeQuestion,
            QuestionCount = model?.QuestionCount,
            Certificate = model.Certificate,
            IsActive = model.IsActive,
            CourseSections = findSection
        };
        await _courseQuizesWrite.AddAsync(newQuiz);
        await _courseQuizesWrite.SaveAsync();

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
                    IsCorrect = answer?.IsCorrect,
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

        _courseQuizesWrite.Update(findQuiz);
        await _courseQuizesWrite.SaveAsync();
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


    public async Task<Response<DeleteCourseSectionCommandResponse>> DeleteCourseSection(DeleteCourseSectionCommandRequest model)
    {
        await _courseSectionWrite.RemoveAsync(model.SectionId.ToString());
        await _courseSectionWrite.SaveAsync();
        return Response<DeleteCourseSectionCommandResponse>.Success("Course section deleted");
    }

    public async Task<Response<DeleteCourseQuestionCommandResponse>> DeleteCourseQuestion(DeleteCourseQuestionCommandRequest model)
    {
        var result = await _courseQuizQuestionRead.GetWhere(x=>x.Id == model.questionId)       
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
            .ThenInclude(x => x.CourseSources)
            .ThenInclude(x => x.CourseUpload)
            .FirstOrDefaultAsync();
    }
}