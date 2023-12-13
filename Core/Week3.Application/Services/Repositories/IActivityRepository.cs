using Common.Persistence.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.Repositories;

public interface IActivityRepository : IAsyncRepository<Activity, int>, IRepository<Activity, int>
{
}
