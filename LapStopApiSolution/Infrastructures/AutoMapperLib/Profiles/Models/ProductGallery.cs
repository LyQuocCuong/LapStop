using AutoMapper;
using Domains.Models;
using DTO.Output.Data;

namespace AutoMapperLib.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingProductGallery()
        {
            Mapping_ProductGallery_To_ProductGalleryDto();
        }

        private void Mapping_ProductGallery_To_ProductGalleryDto()
        {
            CreateMap<ProductGallery, ProductGalleryDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.ProductId,
                           dto_ProductId => dto_ProductId.MapFrom(e => e.ProductId))
                .ForMember(dto => dto.Title,
                           dto_Title => dto_Title.MapFrom(e => e.Title))
                .ForMember(dto => dto.Url,
                           dto_Url => dto_Url.MapFrom(e => e.Url));
        }
    }
}
