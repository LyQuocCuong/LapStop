using Common.Models.Exceptions;
using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class ProductStatusService : ServiceBase, IProductStatusService
    {
        public ProductStatusService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<IEnumerable<ProductStatusDto>> GetAllAsync()
        {
            IEnumerable<ProductStatus> productStatuses = await _repositoryManager.ProductStatus.GetAllAsync(isTrackChanges: false);
            return _mappingService.Map<IEnumerable<ProductStatus>, IEnumerable<ProductStatusDto>>(productStatuses);
        }

        public async Task<ProductStatusDto?> GetOneByIdAsync(Guid productStatusId)
        {
            ProductStatus? productStatus = await _repositoryManager.ProductStatus.GetOneByIdAsync(isTrackChanges: false, productStatusId);
            if (productStatus == null)
            {
                throw new ExNotFoundInDBModel(nameof(ProductStatusService), nameof(GetOneByIdAsync), typeof(ProductStatus), productStatusId);
            }
            return _mappingService.Map<ProductStatus, ProductStatusDto>(productStatus);
        }
    }
}
