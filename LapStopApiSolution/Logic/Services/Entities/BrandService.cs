namespace Services.Entities
{
    internal sealed class BrandService : AbstractService, IBrandService
    {
        public BrandService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        private async Task<Brand> GetBrandAndCheckIfItExists(bool isTrackChanges, Guid brandId)
        {
            Brand? brand = await EntityRepositories.Brand.GetOneByIdAsync(isTrackChanges, brandId);
            if (brand == null)
            {
                throw new ExNotFoundInDBModel(nameof(BrandService), nameof(GetBrandAndCheckIfItExists), typeof(Brand), brandId);
            }
            return brand;
        }

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(HateoasParams<BrandRequestParam> hateoasParams)
        {
            IEnumerable<Brand> brands = await EntityRepositories.Brand.GetAllAsync(isTrackChanges: false, hateoasParams.RequestParams);
            int totalRecords = await EntityRepositories.Brand.CountAllAsync(hateoasParams.RequestParams);
            IEnumerable<BrandDto> brandDtos = UtilityServices.Mapper.ExecuteMapping<IEnumerable<Brand>, IEnumerable<BrandDto>>(brands);

            var hateoasModels = UtilityServices.HateoasShaperForBrand.Execute(
                UtilityServices.DataShaperForBrand,
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
            return UtilityServices.Mapper.ExecuteMapping<Brand, BrandDto>(brand);
        }

        public async Task<BrandForUpdateDto> GetDtoForPatchAsync(Guid brandId)
        {
            Brand brand = await GetBrandAndCheckIfItExists(isTrackChanges: false, brandId);
            return UtilityServices.Mapper.ExecuteMapping<Brand, BrandForUpdateDto>(brand);
        }

        public async Task<bool> IsValidIdAsync(Guid brandId)
        {
            if (await EntityRepositories.Brand.IsValidIdAsync(brandId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(BrandService), nameof(IsValidIdAsync), typeof(Brand), brandId);
            }
            return true;
        }

        public async Task<BrandDto> CreateAsync(BrandForCreationDto creationDto)
        {
            Brand newBrand = UtilityServices.Mapper.ExecuteMapping<BrandForCreationDto, Brand>(creationDto);
            EntityRepositories.Brand.Create(newBrand);
            await SaveChangesToDatabaseAsync();

            return UtilityServices.Mapper.ExecuteMapping<Brand, BrandDto>(newBrand);
        }

        public async Task UpdateAsync(Guid brandId, BrandForUpdateDto updateDto)
        {
            Brand brand = await GetBrandAndCheckIfItExists(isTrackChanges: true, brandId);
            UtilityServices.Mapper.ExecuteMapping<BrandForUpdateDto, Brand>(updateDto, brand);
            await SaveChangesToDatabaseAsync();
        }

        public async Task DeleteAsync(Guid brandId)
        {
            Brand brand = await GetBrandAndCheckIfItExists(isTrackChanges: true, brandId);
            EntityRepositories.Brand.Delete(brand);
            await SaveChangesToDatabaseAsync();
        }
    }
}
