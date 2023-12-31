﻿using Common.Persistence.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid> { }
