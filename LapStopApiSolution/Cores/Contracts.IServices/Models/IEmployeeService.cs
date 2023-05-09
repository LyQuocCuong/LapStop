using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Output.Data;

namespace Contracts.IServices.Models
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId);

        Task<bool> IsValidIdAsync(Guid employeeId);

        Task<EmployeeDto> CreateAsync(EmployeeForCreationDto creationDto);

        Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto updatedDto);

        Task DeleteAsync(Guid employeeId);
    }
}
