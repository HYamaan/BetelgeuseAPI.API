using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course.Content;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class InclusiveCourse:BaseEntity
{
    public Guid CourseBasicInformationId { get; set; }
    public Guid? CoursePricingId { get; set; }
    public CourseBasicInformation CourseBasicInformation { get; set; }
    public CourseExtraInformation? CourseExtraInformation { get; set; }
    public CoursePricing? CoursePricing { get; set; }
    public List<CourseSections> Sections { get; set; }
    public AppUser AppUser { get; set; }


}
