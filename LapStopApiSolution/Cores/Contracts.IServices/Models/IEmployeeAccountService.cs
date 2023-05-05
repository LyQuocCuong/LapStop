using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeAccountService
    {
        List<EmployeeAccountDto> GetAll();

        EmployeeAccountDto? GetOneByEmployeeId(Guid employeeId);
    }
}
