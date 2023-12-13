using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Application.Services.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.ActivityService;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }
    public IResult Add(ActivityAddDto activityAddDto)
    {
        var activityToAdd = new Activity
        {
            Name = activityAddDto.Name,
            Description = activityAddDto.Description,
            DifficultyLevel = activityAddDto.DifficultyLevel,
            Duration = activityAddDto.Duration,
            Date = activityAddDto.Date,
        };
        _activityRepository.Add(activityToAdd);
        return new SuccessResult();
    }

    public IDataResult<PagedList<Activity>> GetActivties(int petId, string sortBy, string sortOrder, int page, int size)
    {
        var activitiesForPet = _activityRepository.GetAll();
        activitiesForPet = activitiesForPet.Where(pa => pa.Id == petId).ToList();
        if (activitiesForPet.Any())
        {
            return new ErrorDataResult<PagedList<Activity>>("No Matching Content");
        }
        if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
        {
            activitiesForPet = activitiesForPet.OrderBy(activitiesForPet => activitiesForPet.Name).ToList();
        }
        else if (sortOrder.ToLower() == "desc")
        {
            activitiesForPet = activitiesForPet.OrderByDescending(activitiesForPet => activitiesForPet.Name).ToList();
        }
        else
        {
            activitiesForPet = activitiesForPet.OrderBy(activitiesForPet => activitiesForPet.Name).ToList();
        }
        var pagedActivities = PagedList<Activity>.Create(activitiesForPet, page, size);
        return new SuccessDataResult<PagedList<Activity>>(pagedActivities);
    }

    public IDataResult<Activity> GetById(int id)
    {
        return new SuccessDataResult<Activity>(_activityRepository.Get(a => a.Id == id));
    }
}
