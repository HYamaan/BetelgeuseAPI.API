namespace BetelgeuseAPI.Application.DTOs.Response.Course.Faq;

public class CourseLogoResponseDto
{
    public Guid Id { get; set; }
    public string LogoUrl { get; set; }
    public string LogoName { get; set; }
    public int Order { get; set; }
}