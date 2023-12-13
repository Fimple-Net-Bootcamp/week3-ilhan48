using Common.Persistence.Repositories;
using Week3.Application.Services.Repositories;
using Week3.Domain.Entities;
using Week3.Persistence.Context;

namespace Week3.Persistence.Repositories;

public class FoodRepository : EfRepositoryBase<Food, int, VirtualPetDbContext>, IFoodRepository
{
    public FoodRepository(VirtualPetDbContext context) : base(context) { }
}
