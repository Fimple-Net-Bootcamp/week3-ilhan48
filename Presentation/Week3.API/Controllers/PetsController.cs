using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.PetService;

namespace Week3.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly IPetService _petService;

    public PetsController(IPetService petService)
    {
        _petService = petService;
    }

    [HttpPost]
    public IActionResult Add(PetAddDto petAddDto)
    {
        var result = _petService.Add(petAddDto);

        if (result.Success)
        {
            return Created("", result);
        }

        return BadRequest(result);
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _petService.GetAll(sortBy, sortOrder, page, size);

        if (result.Success)
        {
            return Ok(result);
        }

        return NotFound(result);
    }

    [HttpGet("{id}", Name = nameof(GetById))]
    public IActionResult GetById(int id)
    {
        var result = _petService.GetById(id);

        if (result.Success)
        {
            return Ok(result);
        }

        return NotFound(result);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, PetUpdateDto petUpdateDto)
    {
        var result = _petService.Update(id, petUpdateDto);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

}
