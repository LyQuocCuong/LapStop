using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.NotFound
{
    public sealed class EmployeeRoleNotFoundException : NotFoundException
    {
        public EmployeeRoleNotFoundException(Guid id) : base($"The EmployeeRole with id: {id} doesn't exist in the database.")
        {
        }
    }
}
