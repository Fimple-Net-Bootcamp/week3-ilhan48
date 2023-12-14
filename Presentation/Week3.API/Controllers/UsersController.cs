using Common.Utilities.Results;
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

    [HttpPost]
    public IActionResult Add(UserForAddDto userForAddDto)
    {
        var userExists = _userService.UserExists(userForAddDto.Email);
        if (!userExists.Success)
        {
            return BadRequest(userExists.Message);
        }
        var userAdd = _userService.Add(userForAddDto, userForAddDto.Password);
        return Created("", userForAddDto);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool status, string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _userService.GetAll(status, sortBy, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = _userService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbymail/{email}")]
    public IActionResult GeyByMail(string email)
    {
        var result = _userService.GetByMail(email);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
