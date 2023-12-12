using Week3.Domain;
using Common.Persistence.Repositories;

namespace Week3.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid> { }
