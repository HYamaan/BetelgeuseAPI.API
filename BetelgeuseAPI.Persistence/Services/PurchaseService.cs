using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Services.Helpers;
using BetelgeuseAPI.Application.Features.Commands.Purchase.PurchaseCourse;
using BetelgeuseAPI.Application.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Application.Repositories.Purchase;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Purchase;

namespace BetelgeuseAPI.Persistence.Services;

public class PurchaseService: IPurchaseService
{
    private readonly IServicesHelper _servicesHelper;

    private readonly IPurchaseReadRepository _purchaseRead;
    private readonly IPurchaseWriteRepository _purchaseWrite;

    private readonly IInclusiveCourseReadRepository _inclusiveCourseRead;
    private readonly IInclusiveCourseWriteRepository _inclusiveCourseWrite;

    public PurchaseService(IPurchaseReadRepository purchaseRead, IPurchaseWriteRepository purchaseWrite, IServicesHelper servicesHelper, IInclusiveCourseWriteRepository inclusiveCourseWrite, IInclusiveCourseReadRepository inclusiveCourseRead)
    {
        _purchaseRead = purchaseRead;
        _purchaseWrite = purchaseWrite;
        _servicesHelper = servicesHelper;
        _inclusiveCourseWrite = inclusiveCourseWrite;
        _inclusiveCourseRead = inclusiveCourseRead;
    }

    public async Task<Response<PurchaseCourseCommandResponse>> PurchaseCourse(PurchaseCourseCommandRequest request)
    {
        try
        {

            var user = _servicesHelper.GetUserIdFromContext();
            var userId = _servicesHelper.GetUserById(user);

            var course = await _inclusiveCourseRead.GetByIdAsync(request.CourseId.ToString());
            if (userId == null || course == null)
            {
                return Response<PurchaseCourseCommandResponse>.Fail("Course or User not found");
            }



            return Response<PurchaseCourseCommandResponse>.Success("Course purchased successfully");
        }
        catch (Exception e)
        {
           return Response<PurchaseCourseCommandResponse>.Fail(e.Message);
        }
    }
}