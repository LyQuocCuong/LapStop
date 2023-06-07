using AutoMapper;

namespace InfraServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingProductBrand()
        {
            Mapping_ProductBrand_To_ProductBrandDto();
        }

        private void Mapping_ProductBrand_To_ProductBrandDto()
        {
            CreateMap<ProductBrand, ProductBrandDto>()
                .ForMember(dto => dto.ProductId,
                           dto_ProductId => dto_ProductId.MapFrom(e => e.ProductId))
                .ForMember(dto => dto.BrandId,
                           dto_BrandId => dto_BrandId.MapFrom(e => e.BrandId));
        }
    }
}
