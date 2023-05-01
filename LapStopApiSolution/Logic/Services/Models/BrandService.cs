using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Creation;
using DTO.Output;
using DTO.Update;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class BrandService : ServiceBase, IBrandService
    {
        public BrandService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public BrandDto Create(BrandForCreationDto creationDto)
        {
            Brand newBrand = MappingToNewObj<Brand>(creationDto);
            _repositoryManager.Brand.Create(newBrand);
            _repositoryManager.SaveChanges();

            return MappingToNewObj<BrandDto>(newBrand);
        }

        public void Update(Guid brandId, BrandForUpdateDto updateDto)
        {
            Brand? brand = _repositoryManager.Brand.GetOneById(isTrackChanges: true, brandId);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(Update), typeof(Brand), brandId);
            }
            MappingToExistingObj(updateDto, brand);
            _repositoryManager.SaveChanges();
        }

        public void Delete(Guid brandId)
        {
            Brand? brand = _repositoryManager.Brand.GetOneById(isTrackChanges: true, brandId);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(Delete), typeof(Brand), brandId);
            }
            _repositoryManager.Brand.Delete(brand);
            _repositoryManager.SaveChanges();
        }

        public List<BrandDto> GetAll(bool isTrackChanges)
        {
            List<Brand> brands = _repositoryManager.Brand.GetAll(isTrackChanges);
            return MappingToNewObj<List<BrandDto>>(brands);
        }

        public BrandDto? GetOneById(bool isTrackChanges, Guid brandId)
        {
            Brand? brand = _repositoryManager.Brand.GetOneById(isTrackChanges, brandId);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(GetOneById),typeof(Brand), brandId);
            }
            return MappingToNewObj<BrandDto>(brand);
        }

    }
}
