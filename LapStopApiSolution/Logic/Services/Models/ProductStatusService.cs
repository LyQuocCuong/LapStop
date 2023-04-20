using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;

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
            return _mapper.Map<List<ProductStatusDto>>(productStatuses);
        }

        public ProductStatusDto? GetById(bool isTrackChanges, Guid id)
        {
            ProductStatus? productStatus = _repositoryManager.ProductStatus.GetById(isTrackChanges, id);
            return _mapper.Map<ProductStatusDto>(productStatus);
        }
    }
}
