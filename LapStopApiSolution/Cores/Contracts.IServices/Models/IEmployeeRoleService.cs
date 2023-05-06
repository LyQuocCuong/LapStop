using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeRoleService
    {
        IEnumerable<EmployeeRoleDto> GetAll();

        EmployeeRoleDto? GetOneById(Guid employeeRoleId);
    }
}
