using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course;

namespace BetelgeuseAPI.Domain.Entities.Purchase;

public class Purchase : BaseEntity
{
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public Guid InclusiveCourseId { get; set; }
    public InclusiveCourse InclusiveCourse { get; set; }
}
