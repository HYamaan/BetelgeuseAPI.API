using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetelgeuseAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class InstructorController:Controller
{
    
}