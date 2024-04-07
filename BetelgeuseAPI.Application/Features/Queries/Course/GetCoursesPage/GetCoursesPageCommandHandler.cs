using BetelgeuseAPI.Application.Abstractions.Services;
using MediatR;

namespace BetelgeuseAPI.Application.Features.Queries.Course.CoursesPage;

public class GetCoursesPageCommandHandler:IRequestHandler<GetCoursesPageCommandRequest, GetCoursesPageCommandResponse>
{
    private readonly ICourseService _courseService;

    public GetCoursesPageCommandHandler(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<GetCoursesPageCommandResponse> Handle(GetCoursesPageCommandRequest request, CancellationToken cancellationToken)
    {
        if(request.Page == null)
            request.Page = 1;

        var result = await _courseService.GetCoursesPage(request);


        return new GetCoursesPageCommandResponse()
        { 
            CourseCount = result.Data.CourseCount ,
            Data = result.Data?.Data,
            Message = result.Message,
            Succeeded = result.Succeeded
        };
    }
}