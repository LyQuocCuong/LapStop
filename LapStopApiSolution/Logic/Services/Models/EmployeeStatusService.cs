using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;

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
            return _mapper.Map<List<EmployeeStatusDto>>(employeeStatuses);
        }

        public EmployeeStatusDto? GetById(bool isTrackChanges, Guid id)
        {
            EmployeeStatus? employeeStatus = _repositoryManager.EmployeeStatus.GetById(isTrackChanges, id);
            return _mapper.Map<EmployeeStatusDto>(employeeStatus); 
        }
    }
}
