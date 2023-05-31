using Common.Models.Exceptions;
using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class EmployeeStatusService : ServiceBase, IEmployeeStatusService
    {
        public EmployeeStatusService(ILogService logService,
                                       IMappingService mappingService,
                                       IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<IEnumerable<EmployeeStatusDto>> GetAllAsync()
        {
            IEnumerable<EmployeeStatus> employeeStatuses = await _repositoryManager.EmployeeStatus.GetAllAsync(isTrackChanges: false);
            return _mappingService.Map<IEnumerable<EmployeeStatus>, IEnumerable<EmployeeStatusDto>>(employeeStatuses);
        }

        public async Task<EmployeeStatusDto?> GetOneByIdAsync(Guid employeeStatusId)
        {
            EmployeeStatus? employeeStatus = await _repositoryManager.EmployeeStatus.GetOneByIdAsync(isTrackChanges: false, employeeStatusId);
            if (employeeStatus == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeStatus), nameof(GetOneByIdAsync), typeof(EmployeeStatus), employeeStatusId);
            }
            return _mappingService.Map<EmployeeStatus, EmployeeStatusDto>(employeeStatus); 
        }
    }
}
