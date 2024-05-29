namespace BetelgeuseAPI.Application.DTOs.Response.Course.CourseDetail;

public class CourseIncludesResponseDto
{
    public bool IsDownloadable { get; set; }
    public bool IsCertificate { get; set; }
    public bool IsSupport { get; set; }
    public int QuizzesCount { get; set; }
}