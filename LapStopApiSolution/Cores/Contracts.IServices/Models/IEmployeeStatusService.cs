using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeStatusService
    {
        List<EmployeeStatusDto> GetAll(bool isTrackChanges);
        EmployeeStatusDto? GetById(bool isTrackChanges, Guid id);
    }
}
