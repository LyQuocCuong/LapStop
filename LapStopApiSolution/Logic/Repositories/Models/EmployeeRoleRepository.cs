using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class EmployeeRoleRepository : RepositoryBase<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(LapStopContext context) : base(context)
        {
        }

        public List<EmployeeRole> GetAll()
        {
            //EmployeeRole employeeRole = FindAll(false).FirstOrDefault();
            List<EmployeeRole> dto = new List<EmployeeRole>()
            {
                new EmployeeRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "abc"
                }
            };
            return dto;
        }
    }
}
