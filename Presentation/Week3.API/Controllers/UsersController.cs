using Common.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.UserService;
using Week3.Domain;

namespace Week3.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Add(UserForAddDto userForAddDto)
    {
        var userExists = _userService.UserExists(userForAddDto.Email);
        if (!userExists.Success)
        {
            return BadRequest(new { error = userExists.Message });
        }

        var userAdd = _userService.Add(userForAddDto, userForAddDto.Password);
        if (userAdd.Success)
        {
            return Created("", userAdd);
        }

        return BadRequest(new { error = userAdd.Message });
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetAll([FromQuery] bool status, string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _userService.GetAll(status, sortBy, sortOrder, page, size);

        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(new { error = result.Message });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetById(Guid id)
    {
        var result = _userService.GetById(id);

        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(new { error = result.Message });
    }

    [HttpGet("getbymail/{email}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetByMail(string email)
    {
        var result = _userService.GetByMail(email);

        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(new { error = result.Message });
    }
}
