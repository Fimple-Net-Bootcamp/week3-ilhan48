using Week3.Application.Services.Repositories;
using Week3.Domain;
using Week3.Persistence.Context;
using Common.Persistence.Repositories;
using Week3.Application.DTOs;

namespace Week3.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, VirtualPetDbContext>, IUserRepository
{
    public UserRepository(VirtualPetDbContext context) : base(context) { }


}
