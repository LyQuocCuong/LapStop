namespace Contracts.IServices.Entities
{
    public interface IEmployeeAccountService
    {
        Task<IEnumerable<EmployeeAccountDto>> GetAllAsync();

        Task<EmployeeAccountDto?> GetOneByEmployeeIdAsync(Guid employeeId);
    }
}
