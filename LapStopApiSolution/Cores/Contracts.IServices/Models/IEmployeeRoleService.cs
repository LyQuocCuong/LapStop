using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeRoleService
    {
        List<EmployeeRoleDto> GetAll(bool isTrackChanges);
    }
}
