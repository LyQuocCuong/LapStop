namespace Contracts.IServices.Entities
{
    public interface IEmployeeRoleService
    {
        Task<IEnumerable<EmployeeRoleDto>> GetAllAsync();

        Task<EmployeeRoleDto?> GetOneByIdAsync(Guid employeeRoleId);
    }
}
