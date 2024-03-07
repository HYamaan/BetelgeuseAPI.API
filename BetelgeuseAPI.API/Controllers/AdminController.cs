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
    
    [HttpPost("[action]")]
    public async Task<IActionResult> AddUserSkill ([FromBody] AddUserSkillCommandRequest model)
    {
        AddUserSkillCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> DeleteUserSkill ([FromBody] DeleteUserSkillCommandRequest model)
    {
        DeleteUserSkillCommandResponse response = await _mediator.Send(model);
        return Ok(response);
    }
    
}