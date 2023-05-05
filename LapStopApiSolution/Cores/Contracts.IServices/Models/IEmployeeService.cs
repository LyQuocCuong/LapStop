using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll();

        EmployeeDto? GetOneById(Guid employeeId);

        bool IsValidId(Guid employeeId);
    }
}
