using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.PetService;

namespace Week3.API.Controllers;

[Route("api/[controller]")]
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
        var petExists = _petService.Add(petAddDto);
        return Created("", petAddDto);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string filter, string sortOrder, int page = 1, int size = 10)
    {
        var result = _petService.GetAll(filter, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
