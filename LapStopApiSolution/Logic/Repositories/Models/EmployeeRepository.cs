﻿using Contracts.IRepositories.Models;
using Domains.Models;
using DTO.Input.FromQuery.Parameters;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(bool isTrackChanges, EmployeeParameter parameter)
        {
            return await FindByCondition(isTrackChanges, 
                            e => DateTime.Now.Year - e.DOB.Year >= parameter.MinAge &&
                                 DateTime.Now.Year - e.DOB.Year <= parameter.MaxAge)
                            .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                            .Take(parameter.PageSize)
                            .ToListAsync();
        }

        public async Task<int> CountAllAsync(EmployeeParameter parameter)
        {
            return await FindByCondition(isTrackChanges: false,
                            e => DateTime.Now.Year - e.DOB.Year >= parameter.MinAge &&
                                 DateTime.Now.Year - e.DOB.Year <= parameter.MaxAge)
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
            base.CreateModel(employee);
        }

        public void Delete(Employee employee)
        {
            base.DeleteModel(employee);
        }
    }
}
