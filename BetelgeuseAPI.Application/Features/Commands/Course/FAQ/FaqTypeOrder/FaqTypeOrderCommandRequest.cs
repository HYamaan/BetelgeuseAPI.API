using BetelgeuseAPI.Application.DTOs.Request.Course.Content;
using BetelgeuseAPI.Domain.Enum;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Course.FAQ.FaqTypeOrder;

public class FaqTypeOrderCommandRequest:IRequest<FaqTypeOrderCommandResponse>
{
    public Guid CourseId { get; set; }
    public FaqAccordionType AccordionType { get; set; }
    public List<CourseTypeOrderRequestDto> Data { get; set; }

}