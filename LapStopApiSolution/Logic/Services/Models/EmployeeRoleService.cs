using AutoMapper;
using Common.Models.Exceptions;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class EmployeeRoleService : ServiceBase, IEmployeeRoleService
    {
        public EmployeeRoleService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<EmployeeRoleDto>> GetAllAsync()
        {
            IEnumerable<EmployeeRole> employeeRoles = await _repositoryManager.EmployeeRole.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<EmployeeRoleDto>>(employeeRoles);
        }

        public async Task<EmployeeRoleDto?> GetOneByIdAsync(Guid employeeRoleId)
        {
            EmployeeRole? employeeRole = await _repositoryManager.EmployeeRole.GetOneByIdAsync(isTrackChanges: false, employeeRoleId);
            if (employeeRole == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeRoleService), nameof(GetOneByIdAsync), typeof(EmployeeRole), employeeRoleId);
            }
            return MappingToNewObj<EmployeeRoleDto>(employeeRole);
        }
    }
}
