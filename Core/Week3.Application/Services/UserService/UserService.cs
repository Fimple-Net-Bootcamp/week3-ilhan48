using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Application.Services.Repositories;
using Week3.Domain;

namespace Week3.Application.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<CreateUser> CreateAsync(CreateUser model)
    {
        throw new NotImplementedException();
    }

    public IDataResult<PagedList<User>> GetAll(bool status, string sortOrder, int page = 1, int size = 10)
    {
        var users =  _userRepository.GetAll();
        users = users.Where(item => item.Status == status).ToList();

        if (users.Count == 0)
        {
            return new ErrorDataResult<PagedList<User>>("No Matching Content");
        }

        if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
        {
            users = users.OrderBy(item => item.FirstName).ToList();
        }
        else if (sortOrder.ToLower() == "desc")
        {
            users = users.OrderByDescending(item => item.FirstName).ToList();
        }
        else
        {
            users = users.OrderBy(item => item.FirstName).ToList();
        }

        var pagedUsers = PagedList<User>.Create(users, page, size);

        return new SuccessDataResult<PagedList<User>>(pagedUsers);
    }

    public Task<User> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}


    
