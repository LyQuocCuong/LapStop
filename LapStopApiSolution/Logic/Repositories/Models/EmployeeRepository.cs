using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(LapStopContext context) : base(context)
        {
        }

        public List<Employee> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public Employee? GetOneById(bool isTrackChanges, Guid employeeId)
        {
            return FindByCondition(isTrackChanges, e => e.Id == employeeId).FirstOrDefault();
        }

        public bool IsValidId(Guid employeeId)
        {
            return FindByCondition(isTrackChanges: false, e => e.Id == employeeId).Any();
        }
    }
}
