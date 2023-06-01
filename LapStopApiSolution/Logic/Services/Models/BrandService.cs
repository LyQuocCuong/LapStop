using Common.Models.DynamicObjects;
using Common.Models.Exceptions;
using Contracts.IDataShaper;
using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;

namespace Services.Models
{
    internal sealed class BrandService : ServiceBase, IBrandService
    {
        private readonly IDataShaperService<BrandDto> _dataShaper;

        public BrandService(ILogService logService,
                            IMappingService mappingService,    
                            IRepositoryManager repositoryManager, 
                            IDataShaperService<BrandDto> dataShaper)
            : base(logService, 
                  mappingService, 
                  repositoryManager)
        {
            _dataShaper = dataShaper;
        }

        private async Task<Brand> GetBrandAndCheckIfItExists(bool isTrackChanges, Guid brandId)
        {
            Brand? brand = await _repositoryManager.Brand.GetOneByIdAsync(isTrackChanges, brandId);
            if (brand == null)
            {
                throw new ExNotFoundInDBModel(nameof(BrandService), nameof(GetBrandAndCheckIfItExists), typeof(Brand), brandId);
            }
            return brand;
        }

        public async Task<PagedList<DynamicModel>> GetAllAsync(BrandParameters parameters)
        {
            IEnumerable<Brand> brands = await _repositoryManager.Brand.GetAllAsync(isTrackChanges: false, parameters);
            int totalRecords = await _repositoryManager.Brand.CountAllAsync(parameters);

            IEnumerable<BrandDto> brandDtos = _mappingService.Map<IEnumerable<Brand>, IEnumerable<BrandDto>>(brands);

            var shapedData = _dataShaper.ShapingData(brandDtos, parameters.Fields);

            return new PagedList<DynamicModel>(shapedData.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<BrandDto?> GetOneByIdAsync(Guid brandId)
        {
            Brand brand = await GetBrandAndCheckIfItExists(isTrackChanges: false, brandId);
            return _mappingService.Map<Brand, BrandDto>(brand);
        }

        public async Task<BrandForUpdateDto> GetDtoForPatchAsync(Guid brandId)
        {
            Brand brand = await GetBrandAndCheckIfItExists(isTrackChanges: false, brandId);
            return _mappingService.Map<Brand, BrandForUpdateDto>(brand);
        }

        public async Task<bool> IsValidIdAsync(Guid brandId)
        {
            if (await _repositoryManager.Brand.IsValidIdAsync(brandId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(BrandService), nameof(IsValidIdAsync), typeof(Brand), brandId);
            }
            return true;
        }

        public async Task<BrandDto> CreateAsync(BrandForCreationDto creationDto)
        {
            Brand newBrand = _mappingService.Map<BrandForCreationDto, Brand>(creationDto);
            _repositoryManager.Brand.Create(newBrand);
            await _repositoryManager.SaveChangesAsync();

            return _mappingService.Map<Brand, BrandDto>(newBrand);
        }

        public async Task UpdateAsync(Guid brandId, BrandForUpdateDto updateDto)
        {
            Brand brand = await GetBrandAndCheckIfItExists(isTrackChanges: true, brandId);
            _mappingService.Map<BrandForUpdateDto, Brand>(updateDto, brand);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid brandId)
        {
            Brand brand = await GetBrandAndCheckIfItExists(isTrackChanges: true, brandId);
            _repositoryManager.Brand.Delete(brand);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
