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

        public IEnumerable<ProductStatusDto> GetAll()
        {
            IEnumerable<ProductStatus> productStatuses = _repositoryManager.ProductStatus.GetAll();
            return _mapper.Map<IEnumerable<ProductStatusDto>>(productStatuses);
        }
    }
}
