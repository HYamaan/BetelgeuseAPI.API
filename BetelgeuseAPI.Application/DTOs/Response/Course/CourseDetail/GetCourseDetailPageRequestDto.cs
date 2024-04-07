using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Application.DTOs.Response.Course.CourseDetail;

public class GetCourseDetailPage
{
    public CourseInformationResponseDto CourseInformation { get; set; }
    public CourseIncludesResponseDto CourseIncludes { get; set; }
    public CourseSpecificationsResponseDto CourseSpecifications { get; set; }
    public List<ModeratorInformation> CourseModeratorInformation { get; set; }

    public List<CourseContentResponseDto> CourseContentDetail { get; set; }

}