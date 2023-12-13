using Common.Persistence.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.Repositories;

public interface IHealthStatusRepository : IAsyncRepository<HealthStatus, int>,
                                           IRepository<HealthStatus, int>
{
}
