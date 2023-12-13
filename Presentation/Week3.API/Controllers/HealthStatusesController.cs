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
    public async Task<IActionResult> GetAll([FromQuery] string filter, string sortOrder, int page = 1, int size = 10)
    {
        var result = _healthStatusService.GetAll(filter, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPatch]
    public IActionResult PatchHealthStatus(int id, [FromBody] JsonPatchDocument<HealthStatusUpdateDto> patchDocument)
    {
        if (patchDocument == null)
        {
            return BadRequest(ModelState);
        }

        var healthStatusFromRepo = _healthStatusService.GetById(id);
        if (healthStatusFromRepo == null)
        {
            return NotFound();
        }

        var healthStatusToPatch = new HealthStatusUpdateDto();
        patchDocument.ApplyTo(healthStatusToPatch, (Microsoft.AspNetCore.JsonPatch.JsonPatchError err) => ModelState.AddModelError("JsonPatch", err.ErrorMessage));

        if(!TryValidateModel(healthStatusToPatch))
        {
            return BadRequest();
        }

        var result = _healthStatusService.Update(healthStatusToPatch);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

}
