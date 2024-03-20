using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course.UploadCourseFile;

public class Source : BaseEntity
{
    public bool Active { get; set; }
    public string Language { get; set; }
    public string Section { get; set; }
    public string Title { get; set; }

    public string SourceType { get; set; }
    public string Description { get; set; }
    public string FileUrl { get; set; }
    public string FileType { get; set; }

    public string Accessibility { get; set; }

    public string AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}