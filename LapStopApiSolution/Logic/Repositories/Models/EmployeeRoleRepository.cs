using Contracts.IRepositories.Models;
using Domains.Models;
using DTO.Output;
using Entities.Context;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    internal sealed class EmployeeRoleRepository : RepositoryBase<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(LapStopContext context) : base(context)
        {
        }

        public List<EmployeeRoleDto> GetAll()
        {
            EmployeeRole employeeRole = FindAll(false).FirstOrDefault();
            List<EmployeeRoleDto> dto = new List<EmployeeRoleDto>()
            {
                new EmployeeRoleDto()
                {
                    Id = employeeRole.Id,
                    Name = employeeRole.Name
                }
            };
            return dto;
        }
    }
}
