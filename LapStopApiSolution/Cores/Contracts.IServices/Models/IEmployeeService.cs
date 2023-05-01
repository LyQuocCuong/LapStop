using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll(bool isTrackChanges);

        EmployeeDto? GetOneById(bool isTrackChanges, Guid employeeId);

        bool IsValidId(Guid employeeId);
    }
}
