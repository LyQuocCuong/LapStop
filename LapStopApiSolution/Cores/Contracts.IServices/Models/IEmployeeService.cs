using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId);

        Task<bool> IsValidIdAsync(Guid employeeId);
    }
}
