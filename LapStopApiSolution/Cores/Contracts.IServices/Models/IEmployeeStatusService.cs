using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeStatusService
    {
        List<EmployeeStatusDto> GetAll(bool isTrackChanges);

        EmployeeStatusDto? GetOneById(bool isTrackChanges, Guid employeeStatusId);
    }
}
