using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    internal sealed class EmployeeAccountRepository : RepositoryBase<EmployeeAccount>, IEmployeeAccountRepository
    {
        public EmployeeAccountRepository(LapStopContext context) : base(context)
        {
        }
    }
}
