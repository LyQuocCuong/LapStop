﻿using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class BrandService : ServiceBase, IBrandService
    {
        public BrandService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<BrandDto> CreateAsync(BrandForCreationDto creationDto)
        {
            Brand newBrand = MappingToNewObj<Brand>(creationDto);
            _repositoryManager.Brand.Create(newBrand);
            await _repositoryManager.SaveChangesAsync();

            return MappingToNewObj<BrandDto>(newBrand);
        }

        public async Task UpdateAsync(Guid brandId, BrandForUpdateDto updateDto)
        {
            Brand? brand = await _repositoryManager.Brand.GetOneByIdAsync(isTrackChanges: true, brandId);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(UpdateAsync), typeof(Brand), brandId);
            }
            MappingToExistingObj(updateDto, brand);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid brandId)
        {
            Brand? brand = await _repositoryManager.Brand.GetOneByIdAsync(isTrackChanges: true, brandId);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(DeleteAsync), typeof(Brand), brandId);
            }
            _repositoryManager.Brand.Delete(brand);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<PagedList<BrandDto>> GetAllAsync(BrandParameters parameters)
        {
            IEnumerable<Brand> brands = await _repositoryManager.Brand.GetAllAsync(isTrackChanges: false, parameters);
            int totalRecords = await _repositoryManager.Brand.CountAllAsync(parameters);

            IEnumerable<BrandDto> sourceDto = MappingToNewObj<IEnumerable<BrandDto>>(brands);
            return new PagedList<BrandDto>(sourceDto.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<BrandDto?> GetOneByIdAsync(Guid brandId)
        {
            Brand? brand = await _repositoryManager.Brand.GetOneByIdAsync(isTrackChanges: false, brandId);
            if (brand == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(GetOneByIdAsync),typeof(Brand), brandId);
            }
            return MappingToNewObj<BrandDto>(brand);
        }

        public async Task<BrandForUpdateDto> GetDtoForPatchAsync(Guid brandId)
        {
            Brand? brand = await _repositoryManager.Brand.GetOneByIdAsync(isTrackChanges: false, brandId);
            return MappingToNewObj<BrandForUpdateDto>(brand);
        }

        public async Task<bool> IsValidIdAsync(Guid brandId)
        {
            if (await _repositoryManager.Brand.IsValidIdAsync(brandId) == false)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(IsValidIdAsync), typeof(Brand), brandId);
            }
            return true;
        }
    }
}
