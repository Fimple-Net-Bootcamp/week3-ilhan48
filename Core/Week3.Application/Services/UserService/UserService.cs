using Common.Utilities.Hashing;
using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Application.Services.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IResult Add(UserForAddDto userForAddDto, string password)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        var user = new User
        {
            Email = userForAddDto.Email,
            FirstName = userForAddDto.FirstName,
            LastName = userForAddDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        _userRepository.Add(user);
        return new SuccessDataResult<User>(user, "User Registered");
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
    public IResult UserExists(string email)
    {

        if (GetByMail(email).Data != null)
        {
            return new ErrorResult("User Already Exists");
        }
        return new SuccessResult();
    }

    public IDataResult<User> GetById(Guid id)
    {
        return new SuccessDataResult<User>(_userRepository.Get(u => u.Id == id));
    }
    public IDataResult<User> GetByMail(string email)
    {
        return new SuccessDataResult<User>(_userRepository.Get(u => u.Email == email));
    }

}


    
