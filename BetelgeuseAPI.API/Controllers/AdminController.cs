using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.AddUserSkills;
using BetelgeuseAPI.Application.Features.Commands.Admin.AllUserSkills.DeleteUserSkills;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AdminController:Controller
{
    
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> AddAllUserSkill ([FromBody] AddAllUserSkillCommandRequest model)
    {
        AddAllUserSkillCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }


    [Authorize]
    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteAllUserSkill ([FromBody] DeleteAllUserSkillCommandRequest model)
    {
        DeleteAllUserSkillCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }


}