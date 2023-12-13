using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Application.Services.Repositories;
using Week3.Domain.Entities;

namespace Week3.Application.Services.HealthStatusService;

public class HealthStatusService : IHealthStatusService
{
    private readonly IHealthStatusRepository _healthStatusRepository;
    public HealthStatusService(IHealthStatusRepository healthStatusRepository)
    {
        _healthStatusRepository = healthStatusRepository;
    }
    public IDataResult<PagedList<HealthStatus>> GetAll(string filterParam, string sortOrder, int page, int size)
    {
        var healthStatuses = _healthStatusRepository.GetAll();
        healthStatuses = healthStatuses.Where(item => item.DeletedDate == null).ToList();

        if (healthStatuses.Count == 0)
        {
            return new ErrorDataResult<PagedList<HealthStatus>>("No Matching Content");
        }

        if (string.IsNullOrEmpty(sortOrder) || sortOrder.ToLower() == "asc")
        {
            healthStatuses = healthStatuses.OrderBy(item => item.CreatedDate).ToList();
        }
        else if (sortOrder.ToLower() == "desc")
        {
            healthStatuses = healthStatuses.OrderByDescending(item => item.CreatedDate).ToList();
        }
        else
        {
            healthStatuses = healthStatuses.OrderBy(item => item.CreatedDate).ToList();
        }

        var pagedHealthStatuses = PagedList<HealthStatus>.Create(healthStatuses, page, size);

        return new SuccessDataResult<PagedList<HealthStatus>>(pagedHealthStatuses);
    }

    public IDataResult<HealthStatus> GetById(int id)
    {
        return new SuccessDataResult<HealthStatus>(_healthStatusRepository.Get(hs => hs.Id == id));
    }

    public IResult Update(HealthStatusUpdateDto healthStatusUpdateDto)
    {
        var healthStatusToUpdate = new HealthStatus
        {
            ExaminationDate = healthStatusUpdateDto.ExaminationDate,
            VaccinationStatus = healthStatusUpdateDto.VaccinationStatus,
            DiseaseStatus = healthStatusUpdateDto.DiseaseStatus,
            TreatmentInfo = healthStatusUpdateDto.TreatmentInfo,
            Notes = healthStatusUpdateDto.Notes,
        };

        _healthStatusRepository.Update(healthStatusToUpdate);
        return new SuccessResult();
    }
}
