namespace Services.Models
{
    internal sealed class BrandService : ServiceBase, IBrandService
    {
        private readonly IDataShaperService<BrandDto, ExpandoForXmlObject> _dataShaperService;
        private readonly IHateoasWithShaperService<BrandDto, ExpandoForXmlObject> _hateoasWithShaperService;

        public BrandService(ILogService logService,
                            IMappingService mappingService,    
                            IRepositoryManager repositoryManager,
                            IDataShaperService<BrandDto, ExpandoForXmlObject> dataShaperService,
                            IHateoasWithShaperService<BrandDto, ExpandoForXmlObject> hateoasWithShaperService)
            : base(logService, 
                  mappingService, 
                  repositoryManager)
        {
            _dataShaperService = dataShaperService;
            _hateoasWithShaperService = hateoasWithShaperService;
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

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(HateoasParams<BrandRequestParam> hateoasParams)
        {
            IEnumerable<Brand> brands = await _repositoryManager.Brand.GetAllAsync(isTrackChanges: false, hateoasParams.RequestParams);
            int totalRecords = await _repositoryManager.Brand.CountAllAsync(hateoasParams.RequestParams);
            IEnumerable<BrandDto> brandDtos = _mappingService.Map<IEnumerable<Brand>, IEnumerable<BrandDto>>(brands);

            var hateoasModels = _hateoasWithShaperService.Execute(
                _dataShaperService,
                hateoasParams.HttpContext, 
                brandDtos,
                hateoasParams.RequestParams.ShapingProps);

            return new PagedList<ExpandoForXmlObject>(
                hateoasModels.ToList(), 
                totalRecords,
                hateoasParams.RequestParams.PageNumber,
                hateoasParams.RequestParams.PageSize);
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
