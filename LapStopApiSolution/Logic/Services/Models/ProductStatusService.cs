using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class ProductStatusService : ServiceBase, IProductStatusService
    {
        public ProductStatusService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<ProductStatusDto> GetAll(bool isTrackChanges)
        {
            List<ProductStatus> productStatuses = _repositoryManager.ProductStatus.GetAll(isTrackChanges);
            return MappingToNewObj<List<ProductStatusDto>>(productStatuses);
        }

        public ProductStatusDto? GetOneById(bool isTrackChanges, Guid productStatusId)
        {
            ProductStatus? productStatus = _repositoryManager.ProductStatus.GetOneById(isTrackChanges, productStatusId);
            if (productStatus == null)
            {
                throw new ExNotFoundInDB(nameof(ProductStatusService), nameof(GetOneById), typeof(ProductStatus), productStatusId);
            }
            return MappingToNewObj<ProductStatusDto>(productStatus);
        }
    }
}
