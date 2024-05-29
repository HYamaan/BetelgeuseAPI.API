using System.ComponentModel;
using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Course.Content;
using BetelgeuseAPI.Domain.Entities.Course.FAQ;
using BetelgeuseAPI.Domain.Entities.Course.Pricing;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class InclusiveCourse:BaseEntity
{
    [DefaultValue(false)]
    public bool isActive { get; set; }

    [DefaultValue(false)]
    public bool Published { get; set; }
    public Guid CourseBasicInformationId { get; set; }
    public Guid? CoursePricingId { get; set; }
    public CourseBasicInformation CourseBasicInformation { get; set; }
    public CourseExtraInformation? CourseExtraInformation { get; set; }
    public CoursePricing? CoursePricing { get; set; }
    public ICollection<CourseSections> Sections { get; set; }


    public ICollection<FaqOption> Faqs { get; set; }
    public ICollection<FaqLearningMaterial> FaqLearningMaterial { get; set; }
    public ICollection<FaqUploadLogo> FaqUploadLogo { get; set; }
    public ICollection<FaqRequirements> FaqRequirements { get; set; }
    
    public MessageToReviewer? MessageToReviewer { get; set; }
    public AppUser AppUser { get; set; }

    public ICollection<Purchase.Purchase> Purchases { get; set; }

}
