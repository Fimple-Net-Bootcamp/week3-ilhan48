using Common.Utilities.Paging;
using Common.Utilities.Results;
using Week3.Application.DTOs;
using Week3.Domain.Entities;

namespace Week3.Application.Services.HealthStatusService;

public interface IHealthStatusService
{
    IDataResult<PagedList<HealthStatus>> GetAll(string sortBy, string sortOrder, int page, int size);
    IResult Update(HealthStatusUpdateDto healthStatusUpdateDto);
    IDataResult<HealthStatus> GetById(int id);
}
