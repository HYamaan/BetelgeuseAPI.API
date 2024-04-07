namespace BetelgeuseAPI.Application.DTOs.Response.Course.CourseDetail;

public class CourseContentResponseDto
{
    public string Title { get; set; }
    public List<CourseContentDetailResponseDto> CourseContentDetails { get; set; }
}