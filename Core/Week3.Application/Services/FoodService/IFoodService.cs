using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Domain.Entities;

namespace Week3.Application.Services.FoodService;

public interface IFoodService
{
    IDataResult<PagedList<Food>> GetAll(string filterParam, string sortOrder, int page, int size);
    IResult Add(FoodAddDto foodAddDto);
}
