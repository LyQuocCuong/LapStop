using DTO.Output.Data;

namespace Contracts.IServices.Models
{
    public interface IEmployeeAccountService
    {
        Task<IEnumerable<EmployeeAccountDto>> GetAllAsync();

        Task<EmployeeAccountDto?> GetOneByEmployeeIdAsync(Guid employeeId);
    }
}
