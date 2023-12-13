using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.ActivityService;
using Week3.Application.Services.Repositories;

namespace Week3.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _activityService;
    public ActivitiesController(IActivityService activityService)
    {
        _activityService = activityService;
    }
    [HttpPost]
    public async Task<IActionResult> Add(ActivityAddDto activityAddDto)
    {
        _activityService.Add(activityAddDto);
        return Created("", activityAddDto);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int petId, string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _activityService.GetActivties(petId, sortBy, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
