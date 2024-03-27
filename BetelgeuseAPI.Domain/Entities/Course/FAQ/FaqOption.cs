using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course.FAQ;

public class FaqOption:BaseEntity
{
    public int Order { get; set; }
    public Languages LanguageId { get; set; }
    public string Title { get; set; }
    public string Answer { get; set; }
    
}