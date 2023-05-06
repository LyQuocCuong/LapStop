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

        public IEnumerable<EmployeeGalleryDto> GetAllByEmployeeId(Guid employeeId)
        {
            if (_repositoryManager.Employee.IsValidId(employeeId) == false)
            {
                throw new ExNotFoundInDB(nameof(EmployeeAccountService), nameof(GetAllByEmployeeId), typeof(Employee), employeeId);
            }
            IEnumerable<EmployeeGallery> employeeGalleries = _repositoryManager.EmployeeGallery.GetAllByEmployeeId(isTrackChanges: false, employeeId);
            return MappingToNewObj<IEnumerable<EmployeeGalleryDto>>(employeeGalleries);
        }
    }
}
