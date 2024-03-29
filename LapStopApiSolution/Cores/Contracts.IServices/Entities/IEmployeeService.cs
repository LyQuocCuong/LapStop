﻿using DTO.Output.ApiResponses.Bases;

namespace Contracts.IServices.Entities
{
    public interface IEmployeeService
    {
        Task<ApiResponseBase> GetAllAsync(EmployeeRequestParam parameter);

        Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId);

        Task<EmployeeForUpdateDto> GetDtoForPatchAsync(Guid employeeId);

        Task<bool> IsValidIdAsync(Guid employeeId);

        Task<EmployeeDto> CreateAsync(EmployeeForCreationDto creationDto);

        Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto updatedDto);

        Task DeleteAsync(Guid employeeId);        
    }
}
