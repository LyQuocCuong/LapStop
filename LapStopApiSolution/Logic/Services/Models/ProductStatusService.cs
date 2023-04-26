using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomedExceptions;

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

        public ProductStatusDto? GetById(bool isTrackChanges, Guid id)
        {
            ProductStatus? productStatus = _repositoryManager.ProductStatus.GetById(isTrackChanges, id);
            if (productStatus == null)
            {
                throw new NotFoundException404(nameof(ProductStatusService), nameof(GetById), typeof(ProductStatus), id);
            }
            return MappingToNewObj<ProductStatusDto>(productStatus);
        }
    }
}
