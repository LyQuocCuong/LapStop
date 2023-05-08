using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class ProductStatusService : ServiceBase, IProductStatusService
    {
        public ProductStatusService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<ProductStatusDto>> GetAllAsync()
        {
            IEnumerable<ProductStatus> productStatuses = await _repositoryManager.ProductStatus.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<ProductStatusDto>>(productStatuses);
        }

        public async Task<ProductStatusDto?> GetOneByIdAsync(Guid productStatusId)
        {
            ProductStatus? productStatus = await _repositoryManager.ProductStatus.GetOneByIdAsync(isTrackChanges: false, productStatusId);
            if (productStatus == null)
            {
                throw new ExNotFoundInDB(nameof(ProductStatusService), nameof(GetOneByIdAsync), typeof(ProductStatus), productStatusId);
            }
            return MappingToNewObj<ProductStatusDto>(productStatus);
        }
    }
}
