using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course.FAQ;

public class FaqLearningMaterial:BaseEntity
{
    public int Order { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
}