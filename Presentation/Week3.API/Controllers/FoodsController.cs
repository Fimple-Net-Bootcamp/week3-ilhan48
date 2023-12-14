using Microsoft.AspNetCore.Mvc;
using Week3.Application.DTOs;
using Week3.Application.Services.FoodService;

namespace Week3.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodsController : ControllerBase
{
    private readonly IFoodService _foodService;
    public FoodsController(IFoodService foodService)
    {
        _foodService = foodService;
    }
    [HttpPost]
    public async Task<IActionResult> Add(FoodAddDto foodAddDto)
    {
        _foodService.Add(foodAddDto);
        return Created("" ,foodAddDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = _foodService.GetById(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);

    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _foodService.GetAll(sortBy, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
