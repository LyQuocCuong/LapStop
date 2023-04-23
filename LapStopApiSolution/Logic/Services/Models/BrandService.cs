using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomedExceptions;

namespace Services.Models
{
    internal sealed class BrandService : ServiceBase, IBrandService
    {
        public BrandService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<BrandDto> GetAll(bool isTrackChanges)
        {
            List<Brand> brands = _repositoryManager.Brand.GetAll(isTrackChanges);
            return _mapper.Map<List<BrandDto>>(brands);
        }

        public BrandDto? GetById(bool isTrackChanges, Guid id)
        {
            Brand? brand = _repositoryManager.Brand.GetById(isTrackChanges, id);
            if (brand == null)
            {
                throw new NotFoundException404(typeof(Brand), nameof(GetById), id);
            }
            return _mapper.Map<BrandDto>(brand);
        }
    }
}
