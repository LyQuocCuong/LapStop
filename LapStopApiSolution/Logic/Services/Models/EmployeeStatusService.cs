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

        public List<EmployeeStatusDto> GetAll()
        {
            List<EmployeeStatus> employeeStatuses = _repositoryManager.EmployeeStatus.GetAll(isTrackChanges: false);
            return MappingToNewObj<List<EmployeeStatusDto>>(employeeStatuses);
        }

        public EmployeeStatusDto? GetOneById(Guid employeeStatusId)
        {
            EmployeeStatus? employeeStatus = _repositoryManager.EmployeeStatus.GetOneById(isTrackChanges: false, employeeStatusId);
            if (employeeStatus == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeStatus), nameof(GetOneById), typeof(EmployeeStatus), employeeStatusId);
            }
            return MappingToNewObj<EmployeeStatusDto>(employeeStatus); 
        }
    }
}
