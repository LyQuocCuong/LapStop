namespace Services.Models
{
    internal sealed class EmployeeGalleryService : ServiceBase, IEmployeeGalleryService
    {
        public EmployeeGalleryService(ILogService logService,
                                       IMappingService mappingService,
                                       IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }
        public async Task<IEnumerable<EmployeeGalleryDto>> GetAllByEmployeeIdAsync(Guid employeeId)
        {
            if (await _repositoryManager.Employee.IsValidIdAsync(employeeId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeAccountService), nameof(GetAllByEmployeeIdAsync), typeof(Employee), employeeId);
            }
            IEnumerable<EmployeeGallery> employeeGalleries = await _repositoryManager.EmployeeGallery.GetAllByEmployeeIdAsync(isTrackChanges: false, employeeId);
            return _mappingService.Map<IEnumerable<EmployeeGallery>, IEnumerable<EmployeeGalleryDto>>(employeeGalleries);
        }
    }
}
