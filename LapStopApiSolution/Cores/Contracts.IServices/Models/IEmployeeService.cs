using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll();

        EmployeeDto? GetOneById(Guid employeeId);

        bool IsValidId(Guid employeeId);
    }
}
