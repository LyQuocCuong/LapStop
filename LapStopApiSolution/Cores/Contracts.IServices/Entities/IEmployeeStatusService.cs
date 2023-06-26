namespace Contracts.IServices.Entities
{
    public interface IEmployeeStatusService
    {
        Task<IEnumerable<EmployeeStatusDto>> GetAllAsync();

        Task<EmployeeStatusDto?> GetOneByIdAsync(Guid employeeStatusId);
    }
}
