﻿using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Domain.Entities;

namespace Week3.Application.Services.PetService;

public interface IPetService
{
    IDataResult<PagedList<Pet>> GetAll(string filterParam, string sortOrder, int page, int size);
    IDataResult<Pet> GetById(int id);
    IResult Add(PetAddDto petAddDto);
    IResult Update(PetUpdateDto petUpdateDto);
}
