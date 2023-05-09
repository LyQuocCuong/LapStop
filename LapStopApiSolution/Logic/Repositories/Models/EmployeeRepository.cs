using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<Employee?> GetOneByIdAsync(bool isTrackChanges, Guid employeeId)
        {
            return await FindByCondition(isTrackChanges, e => e.Id == employeeId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidIdAsync(Guid employeeId)
        {
            return await FindByCondition(isTrackChanges: false, e => e.Id == employeeId).AnyAsync();
        }

        public void Create(Employee employee)
        {
            base.CreateModel(employee);
        }

        public void Delete(Employee employee)
        {
            base.DeleteModel(employee);
        }
    }
}
