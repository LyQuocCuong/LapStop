using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;

namespace Services.Models
{
    internal sealed class EmployeeRoleService : ServiceBase, IEmployeeRoleService
    {
        public EmployeeRoleService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<EmployeeRoleDto> GetAll(bool isTrackChanges)
        {
            List<EmployeeRole> employeeRoles = _repositoryManager.EmployeeRole.GetAll(isTrackChanges);
            return _mapper.Map<List<EmployeeRoleDto>>(employeeRoles);
        }

        public EmployeeRoleDto? GetById(bool isTrackChanges, Guid id)
        {
            EmployeeRole? employeeRole = _repositoryManager.EmployeeRole.GetById(isTrackChanges, id);
            return _mapper?.Map<EmployeeRoleDto>(employeeRole);
        }
    }
}
