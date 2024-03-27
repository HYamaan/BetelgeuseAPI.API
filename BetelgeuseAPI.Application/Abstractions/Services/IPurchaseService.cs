using BetelgeuseAPI.Application.Features.Commands.Purchase.PurchaseCourse;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Application.Abstractions.Services;

public interface IPurchaseService
{
    Task<Response<PurchaseCourseCommandResponse>> PurchaseCourse(PurchaseCourseCommandRequest request);
}