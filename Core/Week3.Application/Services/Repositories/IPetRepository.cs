using Common.Persistence.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.Repositories;

public interface IPetRepository : IAsyncRepository<Pet, int>, IRepository<Pet, int> { }
