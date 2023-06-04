using Common.Models.DynamicObjects;
using Common.Models.Exceptions;
using Common.Models.HATEOAS;
using Contracts.DataShaper;
using Contracts.HATEOAS;
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
using Microsoft.AspNetCore.Http;

namespace Services.Models
{
    internal sealed class BrandService : ServiceBase, IBrandService
    {
        private readonly IDataShaperService<BrandDto, ExpandoForXmlObject> _dataShaper;
        private readonly IHateoasService<BrandDto, ExpandoForXmlObject> _brandHateoasService;

        public BrandService(ILogService logService,
                            IMappingService mappingService,    
                            IRepositoryManager repositoryManager,
                            IHateoasService<BrandDto, ExpandoForXmlObject> brandHateoasService,
                            IDataShaperService<BrandDto, ExpandoForXmlObject> dataShaper)
            : base(logService, 
                  mappingService, 
                  repositoryManager)
        {
            _dataShaper = dataShaper;
            _brandHateoasService = brandHateoasService;
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

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(HateoasParameters<BrandParameters> parameters)
        {
            IEnumerable<Brand> brands = await _repositoryManager.Brand.GetAllAsync(isTrackChanges: false, parameters.RequestParams);
            int totalRecords = await _repositoryManager.Brand.CountAllAsync(parameters.RequestParams);

            IEnumerable<BrandDto> brandDtos = _mappingService.Map<IEnumerable<Brand>, IEnumerable<BrandDto>>(brands);

            //var shapedData = _dataShaper.ShapingData(brandDtos, parameters.BrandParameters.Fields);

            IEnumerable<ExpandoForXmlObject> hateoasModels = _brandHateoasService.ExecuteHateoas(parameters.HttpContext, brandDtos, parameters.RequestParams.Fields);

            return new PagedList<ExpandoForXmlObject>(hateoasModels.ToList(), totalRecords, parameters.RequestParams.PageNumber, parameters.RequestParams.PageSize); ;
            //return new PagedList<DynamicModel>(shapedData.Select(e => e.DynamicModel).ToList(), totalRecords, parameters.BrandParameters.PageNumber, parameters.BrandParameters.PageSize);
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
