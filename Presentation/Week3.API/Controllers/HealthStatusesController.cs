using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.HealthStatusService;

namespace Week3.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class HealthStatusesController : ControllerBase
{
    private readonly IHealthStatusService _healthStatusService;

    public HealthStatusesController(IHealthStatusService healthStatusService)
    {
        _healthStatusService = healthStatusService;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _healthStatusService.GetAll(sortBy, sortOrder, page, size);

        return result.Success
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchHealthStatus(int id, [FromBody] JsonPatchDocument<HealthStatusUpdateDto> patchDocument)
    {
        if (patchDocument == null)
        {
            return BadRequest(new { error = "Invalid JSON patch document." });
        }

        var healthStatusFromRepo = _healthStatusService.GetById(id);
        if (healthStatusFromRepo == null)
        {
            return NotFound(new { error = $"Health status with id {id} not found." });
        }

        var healthStatusToPatch = new HealthStatusUpdateDto();
        patchDocument.ApplyTo(healthStatusToPatch, ModelState);

        if (!TryValidateModel(healthStatusToPatch))
        {
            return BadRequest(ModelState);
        }

        var result = _healthStatusService.Update(healthStatusToPatch);
        return result.Success
            ? Ok(result)
            : BadRequest(result);
    }
}