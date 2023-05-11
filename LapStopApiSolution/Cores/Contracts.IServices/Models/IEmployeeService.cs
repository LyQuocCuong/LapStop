using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using System.Dynamic;

namespace Contracts.IServices.Models
{
    public interface IEmployeeService
    {
        Task<PagedList<ExpandoObject>> GetAllAsync(EmployeeParameter parameter);

        Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId);

        Task<EmployeeForUpdateDto> GetDtoForPatchAsync(Guid employeeId);

        Task<bool> IsValidIdAsync(Guid employeeId);

        Task<EmployeeDto> CreateAsync(EmployeeForCreationDto creationDto);

        Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto updatedDto);

        Task DeleteAsync(Guid employeeId);        
    }
}
