using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeStatusService : ServiceBase, IEmployeeStatusService
    {
        public EmployeeStatusService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<EmployeeStatusDto>> GetAllAsync()
        {
            IEnumerable<EmployeeStatus> employeeStatuses = await _repositoryManager.EmployeeStatus.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<EmployeeStatusDto>>(employeeStatuses);
        }

        public async Task<EmployeeStatusDto?> GetOneByIdAsync(Guid employeeStatusId)
        {
            EmployeeStatus? employeeStatus = await _repositoryManager.EmployeeStatus.GetOneByIdAsync(isTrackChanges: false, employeeStatusId);
            if (employeeStatus == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeStatus), nameof(GetOneByIdAsync), typeof(EmployeeStatus), employeeStatusId);
            }
            return MappingToNewObj<EmployeeStatusDto>(employeeStatus); 
        }
    }
}
