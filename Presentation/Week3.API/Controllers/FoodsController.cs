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
        return Created("", foodAddDto);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string filter, string sortBy, string sortOrder, int page = 1, int size = 10)
    {
        var result = _foodService.GetAll(filter, sortOrder, page, size);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
