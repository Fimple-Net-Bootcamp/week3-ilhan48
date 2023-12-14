using Common.Utilities.Paging;
using Common.Utilities.Results;
using System.Linq.Expressions;
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

    public IDataResult<PagedList<Pet>> GetAll(string sortBy, string sortOrder, int page, int size)
    {
        var pets = _petRepository.GetAll();
        pets = pets.Where(item => item.DeletedDate == null).ToList();

        if (pets.Count == 0)
        {
            return new ErrorDataResult<PagedList<Pet>>("No Matching Content");
        }

        if (!string.IsNullOrEmpty(sortBy) && typeof(Pet).GetProperty(sortBy) != null)
        {
            var parameter = Expression.Parameter(typeof(Pet), "x");
            var property = Expression.Property(parameter, sortBy);
            var lambda = Expression.Lambda<Func<Pet, object>>(Expression.Convert(property, typeof(object)), parameter);

            if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
            {
                pets = pets.OrderBy(lambda.Compile()).ToList();
            }
            else if (sortOrder.ToLower() == "desc")
            {
                pets = pets.OrderByDescending(lambda.Compile()).ToList();
            }
            else
            {
                pets = pets.OrderBy(lambda.Compile()).ToList();
            }
        }
        else
        {
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
        }

        var pagedUsers = PagedList<Pet>.Create(pets, page, size);

        return new SuccessDataResult<PagedList<Pet>>(pagedUsers);
    }


    public IDataResult<Pet> GetById(int id)
    {
        return new SuccessDataResult<Pet>(_petRepository.Get(p => p.Id == id));
    }

    public IResult Update(int id, PetUpdateDto petUpdateDto)
    {
        var existingPet = GetById(id).Data;

        if (existingPet == null)
        {
            return new ErrorResult("Pet not found");
        }

        existingPet.Name = petUpdateDto.Name;
        existingPet.Type = petUpdateDto.Type;
        existingPet.BirthDate = petUpdateDto.BirthDate;
        existingPet.Color = petUpdateDto.Color;
        existingPet.Gender = petUpdateDto.Gender;

        _petRepository.Update(existingPet);

        return new SuccessResult("Pet updated.");
    }
}
