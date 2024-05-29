using BetelgeuseAPI.Domain.Entities.Course.Content;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Request.Course.LearningPage;

public class LearningPageContentSourceResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public CourseUploadFileType? FileType { get; set; }


}