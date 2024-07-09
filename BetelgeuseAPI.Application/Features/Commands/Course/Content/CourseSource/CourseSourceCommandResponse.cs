using BetelgeuseAPI.Application.DTOs.Response.Course;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseSource;

public class CourseSourceCommandResponse : ResponseMessageAndSucceeded
{
    public CourseSourceResponsePostDto Data { get; set; }
}