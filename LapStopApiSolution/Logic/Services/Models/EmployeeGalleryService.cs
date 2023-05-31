using AutoMapper;
using Common.Models.Exceptions;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class EmployeeGalleryService : ServiceBase, IEmployeeGalleryService
    {
        public EmployeeGalleryService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<EmployeeGalleryDto>> GetAllByEmployeeIdAsync(Guid employeeId)
        {
            if (await _repositoryManager.Employee.IsValidIdAsync(employeeId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeAccountService), nameof(GetAllByEmployeeIdAsync), typeof(Employee), employeeId);
            }
            IEnumerable<EmployeeGallery> employeeGalleries = await _repositoryManager.EmployeeGallery.GetAllByEmployeeIdAsync(isTrackChanges: false, employeeId);
            return MappingToNewObj<IEnumerable<EmployeeGalleryDto>>(employeeGalleries);
        }
    }
}
