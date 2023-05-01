﻿using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeAccountService : ServiceBase, IEmployeeAccountService
    {
        public EmployeeAccountService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<EmployeeAccountDto> GetAll(bool isTrackChanges)
        {
            List<EmployeeAccount> employeeAccounts = _repositoryManager.EmployeeAccount.GetAll(isTrackChanges);
            return MappingToNewObj<List<EmployeeAccountDto>>(employeeAccounts);
        }

        public EmployeeAccountDto? GetByEmployeeId(bool isTrackChanges, Guid employeeId)
        {
            if (_repositoryManager.Employee.IsValidEmployeeId(employeeId) == false)
            {
                throw new ExNotFoundInDB(nameof(EmployeeAccountService), nameof(GetByEmployeeId), typeof(Employee), employeeId);
            }
            EmployeeAccount? employeeAccount = _repositoryManager.EmployeeAccount.GetByEmployeeId(isTrackChanges, employeeId);
            if (employeeAccount == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeAccountService), nameof(GetByEmployeeId), typeof(EmployeeAccount), employeeId);
            }
            return MappingToNewObj<EmployeeAccountDto>(employeeAccount);
        }
    }
}
