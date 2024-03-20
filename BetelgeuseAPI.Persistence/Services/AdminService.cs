using BetelgeuseAPI.Application.Abstractions.Services;
using BetelgeuseAPI.Application.Abstractions.Services.Helpers;
using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.AddUserSkills;
using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.DeleteUserSkills;
using BetelgeuseAPI.Application.Repositories.UserAccountSkill;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Services;

public class AdminService:IAdminService
{
    private readonly IServicesHelper _servicesHelper;
    private readonly IAllUserAccountSkillWriteRepository _allUserAccountSkillWriteRepository;
    private readonly IAllUserAccountSkillReadRepository _allUserAccountSkillReadRepository;


    public AdminService(IAllUserAccountSkillWriteRepository allUserAccountSkillWriteRepository, IAllUserAccountSkillReadRepository allUserAccountSkillReadRepository, IServicesHelper servicesHelper)
    {
        _allUserAccountSkillWriteRepository = allUserAccountSkillWriteRepository;
        _allUserAccountSkillReadRepository = allUserAccountSkillReadRepository;
        _servicesHelper = servicesHelper;
    }

    public async Task<Response<AddAllUserSkillCommandResponse>> AddUserSkill(AddAllUserSkillCommandRequest request)
    {
        try
        {
            var userId =  _servicesHelper.GetUserIdFromContext();

            var response = await _allUserAccountSkillReadRepository
                .GetWhere(ux => ux.Skill.Trim().ToLower() == request.Skill.Trim().ToLower())
                .FirstOrDefaultAsync();

            if (response == null)
            {
                var newUserSkill = new AllUserSkills()
                {
                    Skill = request.Skill,
                    IsCheck = request.isCheck,
                };

                await _allUserAccountSkillWriteRepository.AddAsync(newUserSkill);
                await _allUserAccountSkillWriteRepository.SaveAsync();
            
                return Response<AddAllUserSkillCommandResponse>.Success("Yetenek Eklendi.");
            }
            else
            {
                return Response<AddAllUserSkillCommandResponse>.Fail("Bu yetenek zaten mevcut.");
            }
        }
        catch (Exception e)
        {
            return Response<AddAllUserSkillCommandResponse>.Fail(e.Message);
        }
    }

    public async Task<Response<DeleteAllUserSkillCommandResponse>> DeleteUserSkill(DeleteAllUserSkillCommandRequest request)
    {
        var skillId = await _allUserAccountSkillReadRepository.GetByIdAsync(request.Id);
        if (skillId == null)
        {
            return Response<DeleteAllUserSkillCommandResponse>.Fail("Yetenek Bulunamadı");
        }

        await _allUserAccountSkillWriteRepository.RemoveAsync(request.Id);
        await _allUserAccountSkillWriteRepository.SaveAsync();
        return Response<DeleteAllUserSkillCommandResponse>.Success("Yetenek başarılı bir şekilde silindi.");
    }


}