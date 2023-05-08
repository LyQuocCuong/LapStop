using DTO.Output.Data;

namespace Contracts.IServices.Models
{
    public interface IEmployeeRoleService
    {
        Task<IEnumerable<EmployeeRoleDto>> GetAllAsync();

        Task<EmployeeRoleDto?> GetOneByIdAsync(Guid employeeRoleId);
    }
}
