using BetelgeuseAPI.Application.DTOs.Request.Course.Content;
using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseTypeOrder;

public class CourseTypeOrderCommandRequest: IRequest<CourseTypeOrderCommandResponse>
{
    public Guid? SectionId { get; set; }

    public SectionAccordionEnum AccordionType { get; set; }

    public List<CourseTypeOrderRequestDto> Data { get; set; }
}