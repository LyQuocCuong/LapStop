﻿namespace Contracts.IRepositories.Entities
{
    public interface IEmployeeAccountRepository
    {
        Task<IEnumerable<EmployeeAccount>> GetAllAsync(bool isTrackChanges);

        Task<EmployeeAccount?> GetOneByEmployeeIdAsync(bool isTrackChanges, Guid employeeId);
    }
}
