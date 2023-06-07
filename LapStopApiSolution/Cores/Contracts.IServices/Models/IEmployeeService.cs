namespace Contracts.IServices.Models
{
    public interface IEmployeeService
    {
        Task<PagedList<ExpandoForXmlObject>> GetAllAsync(EmployeeRequestParam parameter);

        Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId);

        Task<EmployeeForUpdateDto> GetDtoForPatchAsync(Guid employeeId);

        Task<bool> IsValidIdAsync(Guid employeeId);

        Task<EmployeeDto> CreateAsync(EmployeeForCreationDto creationDto);

        Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto updatedDto);

        Task DeleteAsync(Guid employeeId);        
    }
}
