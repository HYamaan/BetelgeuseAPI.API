using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class CourseExtraInformation:BaseEntity
{
    public Guid CategoryId { get; set; }
    public int Duration { get; set; }
    public bool IsCourseForm { get; set; }
    public bool IsSupport { get; set; }
    public bool IsDownloadable { get; set; }
    public bool IsPartnered { get; set; }
    public string Tag { get; set; }
    public string CourseSubLanguage { get; set; }
    public int CourseLevel { get; set; }

    public Category.Category Category { get; set; }
    public AppUser Partner { get; set; }
}