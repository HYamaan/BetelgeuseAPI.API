using System.ComponentModel;
using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.CoursesPage;

public class GetCoursesPageCommandRequest:IRequest<GetCoursesPageCommandResponse>
{
    public CourseSortOrder? SortOrder { get; set; }
    public Guid? CategoryId { get; set; }
    public bool? IsFree { get; set; }
    public bool? IsDiscounted { get; set; }
    public bool? IsDownloadable { get; set; }
    public CourseLevel? CourseLevel { get; set; }
    public CourseClassType? CourseType { get; set; }

    public int Page { get; set; }
 
}