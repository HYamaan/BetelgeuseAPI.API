using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Services.Helpers;
using BetelgeuseAPI.Application.DTOs.Response.Purchases;
using BetelgeuseAPI.Application.Features.Commands.Purchase.PurchaseCourse;
using BetelgeuseAPI.Application.Features.Commands.Purchase.ShoppingBasket;
using BetelgeuseAPI.Application.Features.Commands.Purchase.UpdateFavoriteCourse;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetCourseFavorite;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetPurchaseCourse;
using BetelgeuseAPI.Application.Features.Queries.Purchases.GetShoppingCart;
using BetelgeuseAPI.Application.Repositories.Course.InclusiveCourse;
using BetelgeuseAPI.Application.Repositories.CourseFavorite;
using BetelgeuseAPI.Application.Repositories.Purchase;
using BetelgeuseAPI.Application.Repositories.ShoppingCartItem;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Purchase;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Services;

public class PurchaseService: IPurchaseService
{
    private readonly IServicesHelper _servicesHelper;

    private readonly IPurchaseReadRepository _purchaseRead;
    private readonly IPurchaseWriteRepository _purchaseWrite;

    private readonly IInclusiveCourseReadRepository _inclusiveCourseRead;
    private readonly IInclusiveCourseWriteRepository _inclusiveCourseWrite;

    private readonly ICourseFavoriteReadRepository _courseFavoriteRead;
    private readonly ICourseFavoriteWriteRepository _courseFavoriteWrite;

    private readonly IShoppingCartItemReadRepository _shoppingCartItemRead;
    private readonly IShoppingCartItemWriteRepository _shoppingCartItemWrite;

    public PurchaseService(IPurchaseReadRepository purchaseRead,
        IPurchaseWriteRepository purchaseWrite,
        IServicesHelper servicesHelper, 
        IInclusiveCourseWriteRepository inclusiveCourseWrite,
        IInclusiveCourseReadRepository inclusiveCourseRead,
        ICourseFavoriteReadRepository courseFavoriteRead,
        ICourseFavoriteWriteRepository courseFavoriteWrite,
        IShoppingCartItemReadRepository shoppingCartItemRead, 
        IShoppingCartItemWriteRepository shoppingCartItemWrite)
    {
        _purchaseRead = purchaseRead;
        _purchaseWrite = purchaseWrite;
        _servicesHelper = servicesHelper;
        _inclusiveCourseWrite = inclusiveCourseWrite;
        _inclusiveCourseRead = inclusiveCourseRead;
        _courseFavoriteRead = courseFavoriteRead;
        _courseFavoriteWrite = courseFavoriteWrite;
        _shoppingCartItemRead = shoppingCartItemRead;
        _shoppingCartItemWrite = shoppingCartItemWrite;
    }

    public async Task<Response<PurchaseCourseCommandResponse>> PurchaseCourse(PurchaseCourseCommandRequest request)
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var user = await _servicesHelper.GetUserById(userId);

            var course = await _inclusiveCourseRead.GetByIdAsync(request.CourseId.ToString());
            if (userId == null || course == null || !course.isActive)
            {
                return Response<PurchaseCourseCommandResponse>.Fail("Course or User not found");
            }

            var isValidPurchase = await _purchaseRead
                .GetWhere(x => x.AppUserId == userId && x.InclusiveCourseId == course.Id).FirstOrDefaultAsync();

            if (isValidPurchase != null)
            {
                return Response<PurchaseCourseCommandResponse>.Fail("Course already purchased");
            }

            var purchase = new Purchase
            {
                AppUserId = userId,
                InclusiveCourseId = request.CourseId
            };
            await _purchaseWrite.AddAsync(purchase);
            await _purchaseWrite.SaveAsync();

            return Response<PurchaseCourseCommandResponse>.Success("Course purchased successfully");
        }
        catch (Exception e)
        {
            return Response<PurchaseCourseCommandResponse>.Fail(e.Message);
           
        }
    }

    public async Task<Response<ShoppingBasketCommandResponse>> UpdateToShoppingCart(ShoppingBasketCommandRequest request)
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var user = await _servicesHelper.GetUserById(userId);

            var course = await _inclusiveCourseRead.GetByIdAsync(request.CourseId.ToString());
            if (userId == null || course == null || !course.isActive)
            {
                return Response<ShoppingBasketCommandResponse>.Fail("Course or User not found");
            }
            var isValidShoppingCartItem = await _shoppingCartItemRead
                .GetWhere(x => x.UserId == userId && x.CourseId == course.Id).FirstOrDefaultAsync();
            if (isValidShoppingCartItem == null)
            {
                var item = new ShoppingCartItem()
                {
                    UserId = userId,
                    CourseId = request.CourseId,
                    Quantity = 1
                };
                await _shoppingCartItemWrite.AddAsync(item);
            }
            else
            {
               await _shoppingCartItemWrite.RemoveAsync(isValidShoppingCartItem.Id.ToString());
            }

            await _shoppingCartItemWrite.SaveAsync();
            return Response<ShoppingBasketCommandResponse>.Success("Course added to shopping cart successfully");
        }
        catch (Exception e)
        {
            return Response<ShoppingBasketCommandResponse>.Fail(e.Message);

        }

    }

    public async Task<Response<UpdateFavoriteCourseCommandResponse>> UpdateFavoriteCourse(UpdateFavoriteCourseCommandRequest request)
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            var user = await _servicesHelper.GetUserById(userId);

            var course = await _inclusiveCourseRead.GetByIdAsync(request.CourseId.ToString());
            if (userId == null || course == null || !course.isActive)
            {
                return Response<UpdateFavoriteCourseCommandResponse>.Fail("Course or User not found");
            }
            var isValidFavorite = await _courseFavoriteRead
                .GetWhere(x => x.UserId == userId && x.CourseId == course.Id).FirstOrDefaultAsync();
            if (isValidFavorite == null)
            {
                var item = new CourseFavorite()
                {
                    UserId = userId,
                    CourseId = request.CourseId
                };

                _courseFavoriteWrite.AddAsync(item);
            }
            else
            {
                _courseFavoriteWrite.RemoveAsync(isValidFavorite.Id.ToString());
            }

            await _courseFavoriteWrite.SaveAsync();
            return Response<UpdateFavoriteCourseCommandResponse>.Success("Course added to Favorite successfully");
        }
        catch (Exception e)
        {
            return Response<UpdateFavoriteCourseCommandResponse>.Fail(e.Message);

        }
    }

    public async Task<Response<GetShoppingCartCommandResponse>> GetShoppingCart()
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        var user = await _servicesHelper.GetUserById(userId);
        if (userId == null)
        {
            return Response<GetShoppingCartCommandResponse>.Fail("User not found");
        }

        var shoppingCart = await _shoppingCartItemRead.GetWhere(x => x.UserId == userId).ToListAsync();
        if (!shoppingCart.Any())
        {
            return Response<GetShoppingCartCommandResponse>.Fail("Shopping cart is empty");
        }
        var courseIds = shoppingCart.Select(item => item.CourseId).ToList();
        var nowDate = DateTime.UtcNow;
        var courseInformation = await _inclusiveCourseRead
            .GetWhere(course => courseIds.Contains(course.Id))
            .Select(ux => new ShoppingCartDto()
            {
                Id = ux.Id,
                Title = ux.CourseBasicInformation.Title,
                Price = ux.CoursePricing.Price,
                Image= ux.CourseBasicInformation.CoverImage.Path,
                AuthorId = ux.AppUser.Id,
                AuthorName = ux.AppUser.UserName,
                UserPointAvarage =1, // Daha sonra düzeltilecek
                UserPointCount = 1, // Daha sonra düzeltilecek
                DiscountedPrice = ux.CoursePricing.NewCoursePricingPlan.Where(x => x.StartDate <= nowDate && x.EndDate >= nowDate && x.Capacity > 0).Select(x => x.Price).FirstOrDefault(),
                Time = ux.CourseExtraInformation.Duration,
                CourseSectionCount = ux.Sections.Sum(ux=> ux.CourseTypes.Count),
                CourseLevel = ux.CourseExtraInformation.CourseLevel
            }).ToListAsync();
        var response = new GetShoppingCartCommandResponse()
        {
            Data = courseInformation
        };
        return Response<GetShoppingCartCommandResponse>.Success(response);
    }

    public async Task<Response<GetCourseFavoriteCommandResponse>> GetCourseFavorite()
    {
        var userId = _servicesHelper.GetUserIdFromContext();
        if (userId == null)
        {
            return Response<GetCourseFavoriteCommandResponse>.Fail("User not found");
        }

        var favoriteCart = await _courseFavoriteRead.GetWhere(x => x.UserId == userId).ToListAsync();
        if (!favoriteCart.Any())
        {
            return Response<GetCourseFavoriteCommandResponse>.Fail("Shopping cart is empty");
        }
        var courseIds = favoriteCart.Select(item => item.CourseId).ToList();
        var courseInformation = await _inclusiveCourseRead
            .GetWhere(course => courseIds.Contains(course.Id))
            .Select(ux => new GetCourseFavoriteDto()
            {
                Id = ux.Id,
                Title = ux.CourseBasicInformation.Title,
                Image = ux.CourseBasicInformation.CoverImage.Path,
                AuthorName = ux.AppUser.UserName,
                UserPointAvarage = 1, // Daha sonra düzeltilecek
                Duration = ux.CourseExtraInformation.Duration.ToString(),
                UpdateTime = ux.UpdatedDate.ToString("d MMM yyyy"),
                Category = ux.CourseExtraInformation.Category.Name,
                CourseType = ux.CourseBasicInformation.CourseType.ToString()
            }).ToListAsync();

        var response = new GetCourseFavoriteCommandResponse()
        {
            Data = courseInformation
        };
        return Response<GetCourseFavoriteCommandResponse>.Success(response);
    }

    public async Task<Response<GetPurchaseCourseCommandResponse>> GetPurchaseCourse()
    {
        try
        {
            var userId = _servicesHelper.GetUserIdFromContext();
            if (userId == null)
            {
                return Response<GetPurchaseCourseCommandResponse>.Fail("User not found");
            }

            var purchaseCourse = await _purchaseRead.GetWhere(x => x.AppUserId == userId).ToListAsync();
            if (!purchaseCourse.Any())
            {
                return Response<GetPurchaseCourseCommandResponse>.Fail("Purchase cart is empty");
            }

            var courseIds = purchaseCourse.Select(item => item.InclusiveCourseId).ToList();
            var courseInformation = await _inclusiveCourseRead
                .GetWhere(course => courseIds.Contains(course.Id))
                .Select(ux => new GetPurchasesCourseDto()
                {
                    Id = ux.Id,
                    Title = ux.CourseBasicInformation.Title,
                    Image = ux.CourseBasicInformation.CoverImage.Path,
                    AuthorName = ux.AppUser.UserName,
                    CourseType = ux.CourseBasicInformation.CourseType.ToString(),
                    UserPointAvarage = 1, // Daha sonra düzeltilecek
                    Duration = ux.CourseExtraInformation.Duration.ToString(),
                    UpdateTime = ux.UpdatedDate.ToString("d MMM yyyy"),
                    Category = ux.CourseExtraInformation.Category.Name,
                    Price = ux.CoursePricing.Price.ToString(),
                    DiscountedPrice = ux.CoursePricing.NewCoursePricingPlan
                        .Where(x => x.StartDate <= DateTime.UtcNow && x.EndDate >= DateTime.UtcNow && x.Capacity > 0)
                        .Select(x => x.Price).FirstOrDefault().ToString(),
                    IsDownloadable = ux.CourseExtraInformation.IsDownloadable
                }).ToListAsync();

            var response = new GetPurchaseCourseCommandResponse()
            {
                Data = courseInformation
            };
            return Response<GetPurchaseCourseCommandResponse>.Success(response);
        }
        catch (Exception e)
        {
            return Response<GetPurchaseCourseCommandResponse>.Fail(e.Message);
        }
    }
}