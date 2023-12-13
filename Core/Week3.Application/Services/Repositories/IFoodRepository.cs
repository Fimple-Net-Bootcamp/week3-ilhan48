using Common.Persistence.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.Repositories;

public interface IFoodRepository : IAsyncRepository<Food, int>, IRepository<Food, int> { }
