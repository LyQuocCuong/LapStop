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

        public List<EmployeeStatusDto> GetAll(bool isTrackChanges)
        {
            List<EmployeeStatus> employeeStatuses = _repositoryManager.EmployeeStatus.GetAll(isTrackChanges);
            return MappingToNewObj<List<EmployeeStatusDto>>(employeeStatuses);
        }

        public EmployeeStatusDto? GetById(bool isTrackChanges, Guid id)
        {
            EmployeeStatus? employeeStatus = _repositoryManager.EmployeeStatus.GetById(isTrackChanges, id);
            if (employeeStatus == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeStatus), nameof(GetById), typeof(EmployeeStatus), id);
            }
            return MappingToNewObj<EmployeeStatusDto>(employeeStatus); 
        }
    }
}
