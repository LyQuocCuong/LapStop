using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeAccountService
    {
        List<EmployeeAccountDto> GetAll(bool isTrackChanges);

        EmployeeAccountDto? GetOneByEmployeeId(bool isTrackChanges, Guid employeeId);
    }
}
