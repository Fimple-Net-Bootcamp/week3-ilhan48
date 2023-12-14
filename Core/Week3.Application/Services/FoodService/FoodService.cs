using Common.Utilities.Paging;
using Common.Utilities.Results;
using System.Linq.Expressions;
using Week3.Application.DTOs;
using Week3.Application.Services.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.FoodService;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;
    public FoodService(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }
    public IResult Add(FoodAddDto foodAddDto)
    {
        var foodToAdd = new Food
        {
            Name = foodAddDto.Name,
            PetId = foodAddDto.PetId, 
        };
        _foodRepository.Add(foodToAdd);
        return new SuccessResult();
    }

    public IDataResult<PagedList<Food>> GetAll(string sortBy, string sortOrder, int page, int size)
    {
        var foods = _foodRepository.GetAll();
        foods = foods.Where(item => item.DeletedDate == null).ToList();

        if (foods.Count == 0)
        {
            return new ErrorDataResult<PagedList<Food>>("No Matching Content");
        }

        if (!string.IsNullOrEmpty(sortBy) && typeof(Food).GetProperty(sortBy) != null)
        {
            var parameter = Expression.Parameter(typeof(Food), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda<Func<Food, object>>(Expression.Convert(property, typeof(object)), parameter);

            if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
            {
                foods = foods.OrderBy(lambda.Compile()).ToList();
            }
            else if (sortOrder.ToLower() == "desc")
            {
                foods = foods.OrderByDescending(lambda.Compile()).ToList();
            }
            else
            {
                foods = foods.OrderBy(lambda.Compile()).ToList();
            }
        }
        else
        {
            if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
            {
                foods = foods.OrderBy(item => item.Name).ToList();
            }
            else if (sortOrder.ToLower() == "desc")
            {
                foods = foods.OrderByDescending(item => item.Name).ToList();
            }
            else
            {
                foods = foods.OrderBy(item => item.Name).ToList();
            }
        }

        var pagedUsers = PagedList<Food>.Create(foods, page, size);

        return new SuccessDataResult<PagedList<Food>>(pagedUsers);
    }


    public IDataResult<Food> GetById(int id)
    {
        return new SuccessDataResult<Food>(_foodRepository.Get(f => f.Id == id));
    }
}
