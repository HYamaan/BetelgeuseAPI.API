namespace BetelgeuseAPI.Application.DTOs.Request.Course.LearningPage;

public class LearningPageSectionResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int SectionCount { get; set; }
    public int Order { get; set; }
    public List<LearningPageContentTypeResponseDto>? CourseTypes { get; set; }

}