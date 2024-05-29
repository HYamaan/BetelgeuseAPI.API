using MediatR;

namespace BetelgeuseAPI.Application.Features.Commands.Purchase.UpdateFavoriteCourse;

public class UpdateFavoriteCourseCommandRequest: IRequest<UpdateFavoriteCourseCommandResponse>
{
    public Guid CourseId { get; set; }   
}