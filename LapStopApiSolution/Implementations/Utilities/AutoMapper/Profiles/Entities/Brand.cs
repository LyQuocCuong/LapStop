using AutoMapper;

namespace Utilities.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingBrand()
        {
            Mapping_Brand_To_BrandDto();
            Mapping_BrandForCreationDto_To_Brand();
            Mapping_BrandForUpdateDto_To_Brand_Reverse();
        }

        private void Mapping_Brand_To_BrandDto()
        {
            CreateMap<Brand, BrandDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.Name,
                           dto_Name => dto_Name.MapFrom(e => e.Name))
                .ForMember(dto => dto.Description,
                           dto_Description => dto_Description.MapFrom(e => e.Description))
                .ForMember(dto => dto.AvatarUrl,
                           dto_AvatarUrl => dto_AvatarUrl.MapFrom(e => e.AvatarUrl))
                .ForMember(dto => dto.IsRemoved,
                           dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));
        }

        private void Mapping_BrandForCreationDto_To_Brand()
        {
            CreateMap<BrandForCreationDto, Brand>()
                .ForMember(model => model.Name,
                           model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                           model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl));
        }

        private void Mapping_BrandForUpdateDto_To_Brand_Reverse()
        {
            CreateMap<BrandForUpdateDto, Brand>().ReverseMap()
                .ForMember(model => model.Name,
                           model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                           model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl));
        }

    }
}
