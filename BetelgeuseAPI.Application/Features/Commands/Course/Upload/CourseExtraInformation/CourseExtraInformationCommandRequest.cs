using BetelgeuseAPI.Application.DTOs.Request;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Upload.CourseExtraInformation;

public class CourseExtraInformationCommandRequest : IRequest<CourseExtraInformationCommandResponse>
{
    public Guid CategoryId { get; set; }
    public int Duration { get; set; }
    public bool IsCourseForm { get; set; }
    public bool IsSupport { get; set; }
    public bool IsCertificate { get; set; }
    public bool IsDownloadable { get; set; }
    public bool IsPartnered { get; set; }
    public List<courseExtraInformationTags> Tag { get; set; }
    public CourseLevel CourseLevel { get; set; }

    public Guid CourseId { get; set; }
    public List<SubTitleLanguageId> CourseSubLanguages { get; set; }
    public Guid PartnerId { get; set; }
}