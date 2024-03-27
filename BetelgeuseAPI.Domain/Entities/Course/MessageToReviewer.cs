using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course;

public class MessageToReviewer:BaseEntity
{
    public string Message { get; set; }

    public bool Rules { get; set; }
}