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

        public Employee? GetById(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, e => e.Id == id).FirstOrDefault();
        }

        public bool IsValidEmployeeId(Guid id)
        {
            return FindByCondition(isTrackChanges: false, e => e.Id == id).Any();
        }
    }
}
