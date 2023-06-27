using Repositories.Extensions;

namespace Repositories.Entities
{
    internal sealed class EmployeeRepository : AbstractEntityRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(bool isTrackChanges, 
                                                             EmployeeRequestParam parameter)
        {
            return await FindAll(isTrackChanges)
                            .FilterAgeExt(parameter)
                            .SearchExt(parameter)
                            .OrderByExt(parameter)
                            //.Skip((parameter.PageNumber - 1) * parameter.PageSize)
                            //.Take(parameter.PageSize)
                            .Page(parameter.PageNumber, parameter.PageSize)
                            .ToListAsync();
        }

        public async Task<int> CountAllAsync(EmployeeRequestParam parameter)
        {
            return await FindAll(isTrackChanges: false)
                            .FilterAgeExt(parameter)
                            .SearchExt(parameter)
                            .CountAsync();
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
            base.CreateEntity(employee);
        }

        public void Delete(Employee employee)
        {
            base.DeleteEntity(employee);
        }
    }
}
