using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Domain.Entities;

namespace Week3.Application.Services.UserService;

public interface IUserService
{
    IResult Add(UserForAddDto userForAddDto, string password);
    IDataResult<PagedList<User>> GetAll(bool status, string sortOrder, int page = 1, int size = 10);
    IResult UserExists(string email);
    IDataResult<User> GetById(Guid id);
    IDataResult<User> GetByMail(string email);
}
