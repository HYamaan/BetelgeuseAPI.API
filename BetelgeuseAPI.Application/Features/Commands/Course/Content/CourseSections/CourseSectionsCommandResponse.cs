using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Features.Commands.Course.Content.CourseSections;

public class CourseSectionsCommandResponse : ResponseMessageAndSucceeded
{
    public Guid Id { get; set; }
}