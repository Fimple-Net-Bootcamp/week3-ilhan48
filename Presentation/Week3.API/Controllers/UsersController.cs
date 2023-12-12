using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.UserService;
using Week3.Domain;

namespace Week3.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool status, string sortOrder, int page = 1, int size = 10)
    {
        var result = _userService.GetAll(status, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _userService.GetById(id);
        return Ok(result);
    }
}
