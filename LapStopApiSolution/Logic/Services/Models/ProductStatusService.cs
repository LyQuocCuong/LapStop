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

        public List<ProductStatusDto> GetAll()
        {
            List<ProductStatus> productStatuses = _repositoryManager.ProductStatus.GetAll(isTrackChanges: false);
            return MappingToNewObj<List<ProductStatusDto>>(productStatuses);
        }

        public ProductStatusDto? GetOneById(Guid productStatusId)
        {
            ProductStatus? productStatus = _repositoryManager.ProductStatus.GetOneById(isTrackChanges: false, productStatusId);
            if (productStatus == null)
            {
                throw new ExNotFoundInDB(nameof(ProductStatusService), nameof(GetOneById), typeof(ProductStatus), productStatusId);
            }
            return MappingToNewObj<ProductStatusDto>(productStatus);
        }
    }
}
