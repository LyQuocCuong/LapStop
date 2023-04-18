using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using DTO.Output;

namespace Services.Models
{
    internal sealed class EmployeeRoleService : ServiceBase, IEmployeeRoleService
    {
        public EmployeeRoleService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<EmployeeRoleDto> GetAll()
        {
            var x = _repositoryManager.EmployeeRole.GetAll();
            return new List<EmployeeRoleDto>();
        }
    }
}
