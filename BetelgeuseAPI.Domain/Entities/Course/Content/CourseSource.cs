using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course.Content;

public class CourseSource:BaseEntity
{
    public int Order { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
    public bool IsFree { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string? Link { get; set; }
    public CourseUploadSourceType Source { get; set; }
    public CourseUploadFileType? FileType { get; set; }

    public Guid CourseSectionsId { get; set; }
    public List<CourseUpload>? CourseUpload { get; set; }
    public CourseSections CourseSections { get; set; }

}