using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeRoleService : ServiceBase, IEmployeeRoleService
    {
        public EmployeeRoleService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<EmployeeRoleDto> GetAll()
        {
            List<EmployeeRole> employeeRoles = _repositoryManager.EmployeeRole.GetAll(isTrackChanges: false);
            return MappingToNewObj<List<EmployeeRoleDto>>(employeeRoles);
        }

        public EmployeeRoleDto? GetOneById(Guid employeeRoleId)
        {
            EmployeeRole? employeeRole = _repositoryManager.EmployeeRole.GetOneById(isTrackChanges: false, employeeRoleId);
            if (employeeRole == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeRoleService), nameof(GetOneById), typeof(EmployeeRole), employeeRoleId);
            }
            return MappingToNewObj<EmployeeRoleDto>(employeeRole);
        }
    }
}
