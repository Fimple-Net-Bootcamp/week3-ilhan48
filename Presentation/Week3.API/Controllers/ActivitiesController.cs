using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.ActivityService;

namespace Week3.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivitiesController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpPost]
    public IActionResult Add(ActivityAddDto activityAddDto)
    {
        var result = _activityService.Add(activityAddDto);
        if (result.Success)
        {
            return Created("", result);
        }
        return BadRequest(result);
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] int petId, string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _activityService.GetActivties(petId, sortBy, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return NotFound(result.Message);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _activityService.GetById(id);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return NotFound(result.Message);
    }
}