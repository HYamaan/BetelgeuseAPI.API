using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class InclusiveCourse:BaseEntity
{
    public Guid CourseBasicInformationId { get; set; }
    public Guid? CourseExtraInformationId { get; set; }
    public Guid? CoursePricingId { get; set; }
    public CourseBasicInformation CourseBasicInformation { get; set; }
    public CourseExtraInformation? CourseExtraInformation { get; set; }
    public CoursePricing? CoursePricing { get; set; }
    public AppUser AppUser { get; set; }
}