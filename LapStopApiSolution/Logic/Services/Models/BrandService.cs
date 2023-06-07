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

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(HateoasParameters<BrandRequestParam> parameters)
        {
            IEnumerable<Brand> brands = await _repositoryManager.Brand.GetAllAsync(isTrackChanges: false, parameters.RequestParam);
            int totalRecords = await _repositoryManager.Brand.CountAllAsync(parameters.RequestParam);

            IEnumerable<BrandDto> brandDtos = _mappingService.Map<IEnumerable<Brand>, IEnumerable<BrandDto>>(brands);

            //var shapedData = _dataShaper.ShapingData(brandDtos, parameters.BrandParameters.Fields);

            IEnumerable<ExpandoForXmlObject> hateoasModels = _brandHateoasService.ExecuteHateoas(parameters.HttpContext, brandDtos, parameters.RequestParam.ShapingProps);

            return new PagedList<ExpandoForXmlObject>(hateoasModels.ToList(), totalRecords, parameters.RequestParam.PageNumber, parameters.RequestParam.PageSize); ;
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
