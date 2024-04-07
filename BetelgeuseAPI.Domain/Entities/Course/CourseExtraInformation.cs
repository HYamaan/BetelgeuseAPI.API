using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class CourseExtraInformation:BaseEntity
{
    public Guid CategoryId { get; set; }
    public int Duration { get; set; }
    public bool IsCourseForm { get; set; }
    public bool IsSupport { get; set; }
    public bool IsCertificate { get; set; }
    public bool IsDownloadable { get; set; }
    public bool IsPartnered { get; set; }
    public string Tag { get; set; }
    public CourseLevel CourseLevel { get; set; }

    public Category.Category Category { get; set; }
    public AppUser Partner { get; set; }

    public Guid InclusiveCourseId { get; set; }
    public InclusiveCourse InclusiveCourse { get; set; }

    public ICollection<CourseSubLanguage> CourseSubLanguages { get; set; }
}