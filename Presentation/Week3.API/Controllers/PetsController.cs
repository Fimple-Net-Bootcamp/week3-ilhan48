using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.PetService;

namespace Week3.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    IPetService _petService;
    public PetsController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpPost]
    public IActionResult Add(PetAddDto petAddDto)
    {
        _petService.Add(petAddDto);
        return Created("", petAddDto);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _petService.GetAll(sortBy, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
