using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Domain.Entities;

namespace Week3.Application.Services.ActivityService;

public interface IActivityService
{
    IResult Add(ActivityAddDto activityAddDto);
    IDataResult<PagedList<Activity>> GetActivties(int petId, string sortBy, string sortOrder, int page, int size);
    IDataResult<Activity> GetById(int id);
}
