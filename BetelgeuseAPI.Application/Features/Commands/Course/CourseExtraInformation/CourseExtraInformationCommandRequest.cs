using BetelgeuseAPI.Application.DTOs.Request;
using BetelgeuseAPI.Domain.Entities;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.CourseExtraInformation;

public class CourseExtraInformationCommandRequest:IRequest<CourseExtraInformationCommandResponse>
{
    public Guid CategoryId { get; set; }
    public int Duration { get; set; }
    public bool IsCourseForm { get; set; }
    public bool IsSupport { get; set; }
    public bool IsDownloadable { get; set; }
    public bool IsPartnered { get; set; }
    public string Tag { get; set; }
    public int CourseLevel { get; set; }

    public Guid CourseId { get; set; }
    public List<SubTitleLanguageIdRequest> CourseSubLanguages { get; set; }
    public Guid PartnerId { get; set; }
}