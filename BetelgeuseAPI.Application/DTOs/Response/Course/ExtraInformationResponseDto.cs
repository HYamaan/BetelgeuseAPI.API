using BetelgeuseAPI.Application.DTOs.Request;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course;

public class ExtraInformationResponseDto
{
    public int Duration { get; set; }
    public bool IsCourseForm { get; set; }
    public bool IsSupport { get; set; }
    public bool IsDownloadable { get; set; }
    public bool IsCertificate { get; set; }
    public bool IsPartnered { get; set; }
    public List<courseExtraInformationTags> Tag { get; set; }
    public Guid CategoryId { get; set; }
    public CourseLevel CourseLevel { get; set; }

    public List<SubTitleLanguageId> CourseSubLanguages { get; set; }
}