using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course;

namespace BetelgeuseAPI.Domain.Entities.Purchase;

public class CourseFavorite:BaseEntity
{
    public string UserId { get; set; }
    public Guid CourseId { get; set; }
    public AppUser User { get; set; }
    public InclusiveCourse Course { get; set; }
}