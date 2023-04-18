using Contracts.IRepositories;
using Contracts.IServices.Models;
using DTO.Output;

namespace Services.Models
{
    internal sealed class EmployeeRoleService : ServiceBase, IEmployeeRoleService
    {
        public EmployeeRoleService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }

        public List<EmployeeRoleDto> GetAll()
        {
            return _repositoryManager.EmployeeRole.GetAll();
        }
    }
}
