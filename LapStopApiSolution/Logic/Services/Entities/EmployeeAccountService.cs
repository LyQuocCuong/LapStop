﻿namespace Services.Entities
{
    internal sealed class EmployeeAccountService : AbstractService, IEmployeeAccountService
    {
        public EmployeeAccountService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }

        public async Task<IEnumerable<EmployeeAccountDto>> GetAllAsync()
        {
            IEnumerable<EmployeeAccount> employeeAccounts = await EntityRepositories.EmployeeAccount.GetAllAsync(isTrackChanges: false);
            return UtilServices.Mapper.ExecuteMapping<IEnumerable<EmployeeAccount>, IEnumerable<EmployeeAccountDto>>(employeeAccounts);
        }

        public async Task<EmployeeAccountDto?> GetOneByEmployeeIdAsync(Guid employeeId)
        {
            if (await EntityRepositories.Employee.IsValidIdAsync(employeeId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeAccountService), nameof(GetOneByEmployeeIdAsync), typeof(Employee), employeeId);
            }
            EmployeeAccount? employeeAccount = await EntityRepositories.EmployeeAccount.GetOneByEmployeeIdAsync(isTrackChanges: false, employeeId);
            if (employeeAccount == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeAccountService), nameof(GetOneByEmployeeIdAsync), typeof(EmployeeAccount), employeeId);
            }
            return UtilServices.Mapper.ExecuteMapping<EmployeeAccount, EmployeeAccountDto>(employeeAccount);
        }
    }
}
