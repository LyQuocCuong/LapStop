using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeAccountService
    {
        IEnumerable<EmployeeAccountDto> GetAll();

        EmployeeAccountDto? GetOneByEmployeeId(Guid employeeId);
    }
}
