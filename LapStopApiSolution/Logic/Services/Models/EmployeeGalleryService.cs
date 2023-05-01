using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeGalleryService : ServiceBase, IEmployeeGalleryService
    {
        public EmployeeGalleryService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<EmployeeGalleryDto> GetByEmployeeId(bool isTrackChanges, Guid employeeId)
        {
            if (_repositoryManager.Employee.IsValidEmployeeId(employeeId) == false)
            {
                throw new ExNotFoundInDB(nameof(EmployeeAccountService), nameof(GetByEmployeeId), typeof(Employee), employeeId);
            }
            List<EmployeeGallery> employeeGalleries = _repositoryManager.EmployeeGallery.GetByEmployeeId(isTrackChanges, employeeId);
            return MappingToNewObj<List<EmployeeGalleryDto>>(employeeGalleries);
        }
    }
}
