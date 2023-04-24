using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeAccountService
    {
        List<EmployeeAccountDto> GetAll(bool isTrackChanges);
        EmployeeAccountDto? GetByEmployeeId(bool isTrackChanges, Guid employeeId);
    }
}
