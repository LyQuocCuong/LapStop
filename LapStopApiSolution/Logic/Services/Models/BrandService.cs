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

        public BrandDto CreateBrand(BrandForCreationDto creationDto)
        {
            Brand newBrand = MappingToNewObj<Brand>(creationDto);
            _repositoryManager.Brand.CreateBrand(newBrand);
            _repositoryManager.SaveChanges();

            return MappingToNewObj<BrandDto>(newBrand);
        }

        public void UpdateBrand(Guid id, BrandForUpdateDto updateDto)
        {
            Brand? brand = _repositoryManager.Brand.GetById(isTrackChanges: true, id);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(UpdateBrand), typeof(Brand), id);
            }
            MappingToExistingObj(updateDto, brand);
            _repositoryManager.SaveChanges();
        }

        public void DeleteBrand(Guid id)
        {
            Brand? brand = _repositoryManager.Brand.GetById(isTrackChanges: true, id);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(GetById), typeof(Brand), id);
            }
            _repositoryManager.Brand.DeleteBrand(brand);
            _repositoryManager.SaveChanges();
        }

        public List<BrandDto> GetAll(bool isTrackChanges)
        {
            List<Brand> brands = _repositoryManager.Brand.GetAll(isTrackChanges);
            return MappingToNewObj<List<BrandDto>>(brands);
        }

        public BrandDto? GetById(bool isTrackChanges, Guid id)
        {
            Brand? brand = _repositoryManager.Brand.GetById(isTrackChanges, id);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(GetById),typeof(Brand), id);
            }
            return MappingToNewObj<BrandDto>(brand);
        }

    }
}
