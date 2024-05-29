namespace BetelgeuseAPI.Application.DTOs.Response.Course.CourseDetail;

public class CourseSpecificationsResponseDto
{
    public string Capacity { get; set; }
    public string Duration { get; set; }
    public int StudentCount { get; set; }
    public int DownloadableFileCount { get; set; }

    public string CreatedDate { get; set; }
}