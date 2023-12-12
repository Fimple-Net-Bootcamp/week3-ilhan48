using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Domain;

namespace Week3.Application.Services.UserService;

public interface IUserService
{
    IDataResult<PagedList<User>> GetAll(bool status, string sortOrder, int page = 1, int size = 10);
    Task<CreateUser> CreateAsync(CreateUser model);
    Task<User> GetById(Guid id);
}
