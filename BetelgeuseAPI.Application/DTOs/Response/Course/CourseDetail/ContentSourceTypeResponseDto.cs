namespace BetelgeuseAPI.Application.DTOs.Response.Course.CourseDetail;

public class ContentSourceTypeRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsFree { get; set; }

    public List<ContentUploadResponseDto> ContentUploads { get; set; }
}