using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.FoodService;

namespace Week3.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class FoodsController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodsController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpPost]
    public IActionResult Add(FoodAddDto foodAddDto)
    {
        var result = _foodService.Add(foodAddDto);

        if (result.Success)
        {
            return Created("", result);
        }

        return BadRequest(new { error = result.Message });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _foodService.GetById(id);

        if (result.Success)
        {
            return Ok(result.Data);
        }

        return NotFound(new { error = result.Message });
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _foodService.GetAll(sortBy, sortOrder, page, size);

        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(new { error = result.Message });
    }
}