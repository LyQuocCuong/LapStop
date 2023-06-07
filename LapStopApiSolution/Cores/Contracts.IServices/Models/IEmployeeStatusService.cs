namespace Contracts.IServices.Models
{
    public interface IEmployeeStatusService
    {
        Task<IEnumerable<EmployeeStatusDto>> GetAllAsync();

        Task<EmployeeStatusDto?> GetOneByIdAsync(Guid employeeStatusId);
    }
}
