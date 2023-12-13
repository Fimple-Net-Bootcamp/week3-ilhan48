using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Application.Services.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.PetService;

public class PetService : IPetService
{
    readonly IPetRepository _petRepository;
    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public IResult Add(PetAddDto petAddDto)
    {
        var petToAdd = new Pet
        {
            Name = petAddDto.Name,
            Type = petAddDto.Type,
            BirthDate = petAddDto.BirthDate,
            Color = petAddDto.Color,
            Gender = petAddDto.Gender,
            UserId = petAddDto.UserId,
        };
        _petRepository.Add(petToAdd);
        return new SuccessResult();
    }

    public IDataResult<PagedList<Pet>> GetAll(string filterParam, string sortOrder, int page, int size)
    {
        var pets = _petRepository.GetAll();
        pets = pets.Where(item => item.DeletedDate == null).ToList();

        if (pets.Count == 0)
        {
            return new ErrorDataResult<PagedList<Pet>>("No Matching Content");
        }

        if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
        {
            pets = pets.OrderBy(item => item.Name).ToList();
        }
        else if (sortOrder.ToLower() == "desc")
        {
            pets = pets.OrderByDescending(item => item.Name).ToList();
        }
        else
        {
            pets = pets.OrderBy(item => item.Name).ToList();
        }

        var pagedUsers = PagedList<Pet>.Create(pets, page, size);

        return new SuccessDataResult<PagedList<Pet>>(pagedUsers);
    }

    public IDataResult<Pet> GetById(int id)
    {
        return new SuccessDataResult<Pet>(_petRepository.Get(p => p.Id == id));
    }

    public IResult Update(PetUpdateDto petUpdateDto)
    {
        var petToUpdate = new Pet
        {
            Name = petUpdateDto.Name,
            Type = petUpdateDto.Type,
            BirthDate = petUpdateDto.BirthDate,
            Color = petUpdateDto.Color,
            Gender = petUpdateDto.Gender,
        };

        _petRepository.Update(petToUpdate);
        return new SuccessResult();
    }
}
