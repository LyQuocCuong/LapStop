using Contracts.IServices.Models;
using DTO.Output;
using Entities.Context;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    internal sealed class EmployeeRoleService : ServiceBase, IEmployeeRoleService
    {
        public EmployeeRoleService(LapStopContext context) : base(context)
        {
        }

        public List<EmployeeRoleDto> GetAll()
        {
            using(RepositoryManager repo = new RepositoryManager(_context))
            {
                return repo.EmployeeRole.GetAll();
            }
        }
    }
}
