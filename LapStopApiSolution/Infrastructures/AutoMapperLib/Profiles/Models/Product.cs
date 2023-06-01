using AutoMapper;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Output.Data;

namespace AutoMapperLib.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingProduct()
        {
            Mapping_Product_To_ProductDto();
            Mapping_ProductForCreationDto_To_Product();
            Mapping_ProductForUpdateDto_To_Product_Reverse();
            Mapping_ProductForBulkUpdateDto_To_Product_Reverse();
        }

        private void Mapping_Product_To_ProductDto()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Id,
                            dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.ProductStatusId,
                            dto_ProductStatusId => dto_ProductStatusId.MapFrom(e => e.ProductStatusId))
                .ForMember(dto => dto.ProductStatusName,
                            dto_ProductStatusName => dto_ProductStatusName.MapFrom(e => e.ProductStatus != null ? e.ProductStatus.Name : ""))
                .ForMember(dto => dto.ProductCode,
                            dto_ProductCode => dto_ProductCode.MapFrom(e => e.ProductCode))
                .ForMember(dto => dto.Name,
                            dto_Name => dto_Name.MapFrom(e => e.Name))
                .ForMember(dto => dto.Description,
                            dto_Description => dto_Description.MapFrom(e => e.Description))
                .ForMember(dto => dto.AvatarUrl,
                            dto_AvatarUrl => dto_AvatarUrl.MapFrom(e => e.AvatarUrl))
                .ForMember(dto => dto.OriginalPrice,
                            dto_OriginalPrice => dto_OriginalPrice.MapFrom(e => e.OriginalPrice))
                .ForMember(dto => dto.CurrentPrice,
                            dto_CurrentPrice => dto_CurrentPrice.MapFrom(e => e.CurrentPrice))
                .ForMember(dto => dto.SellingPrice,
                            dto_SellingPrice => dto_SellingPrice.MapFrom(e => e.SellingPrice))
                .ForMember(dto => dto.IsHiddenInStore,
                            dto_IsHiddenInStore => dto_IsHiddenInStore.MapFrom(e => e.IsHiddenInStore));
        }

        private void Mapping_ProductForCreationDto_To_Product()
        {
            CreateMap<ProductForCreationDto, Product>()
                .ForMember(model => model.ProductStatusId,
                            model_field => model_field.MapFrom(e => e.ProductStatusId))
                .ForMember(model => model.ProductCode,
                            model_field => model_field.MapFrom(e => e.ProductCode))
                .ForMember(model => model.Name,
                            model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                            model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                            model_field => model_field.MapFrom(e => e.AvatarUrl))
                .ForMember(model => model.OriginalPrice,
                            model_field => model_field.MapFrom(e => e.OriginalPrice))
                .ForMember(model => model.CurrentPrice,
                            model_field => model_field.MapFrom(e => e.CurrentPrice))
                .ForMember(model => model.SellingPrice,
                            model_field => model_field.MapFrom(e => e.SellingPrice))
                .ForMember(model => model.IsHiddenInStore,
                            model_field => model_field.MapFrom(e => e.IsHiddenInStore));
        }

        private void Mapping_ProductForUpdateDto_To_Product_Reverse()
        {
            CreateMap<ProductForUpdateDto, Product>().ReverseMap()
                .ForMember(model => model.ProductStatusId,
                            model_field => model_field.MapFrom(e => e.ProductStatusId))
                .ForMember(model => model.ProductCode,
                            model_field => model_field.MapFrom(e => e.ProductCode))
                .ForMember(model => model.Name,
                            model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                            model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                            model_field => model_field.MapFrom(e => e.AvatarUrl))
                .ForMember(model => model.OriginalPrice,
                            model_field => model_field.MapFrom(e => e.OriginalPrice))
                .ForMember(model => model.CurrentPrice,
                            model_field => model_field.MapFrom(e => e.CurrentPrice))
                .ForMember(model => model.SellingPrice,
                            model_field => model_field.MapFrom(e => e.SellingPrice))
                .ForMember(model => model.IsHiddenInStore,
                            model_field => model_field.MapFrom(e => e.IsHiddenInStore));
        }

        private void Mapping_ProductForBulkUpdateDto_To_Product_Reverse()
        {
            CreateMap<ProductForBulkUpdateDto, Product>().ReverseMap()
                .ForMember(model => model.Id,
                            model_field => model_field.MapFrom(e => e.Id))
                .ForMember(model => model.ProductStatusId,
                            model_field => model_field.MapFrom(e => e.ProductStatusId))
                .ForMember(model => model.ProductCode,
                            model_field => model_field.MapFrom(e => e.ProductCode))
                .ForMember(model => model.Name,
                            model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                            model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                            model_field => model_field.MapFrom(e => e.AvatarUrl))
                .ForMember(model => model.OriginalPrice,
                            model_field => model_field.MapFrom(e => e.OriginalPrice))
                .ForMember(model => model.CurrentPrice,
                            model_field => model_field.MapFrom(e => e.CurrentPrice))
                .ForMember(model => model.SellingPrice,
                            model_field => model_field.MapFrom(e => e.SellingPrice))
                .ForMember(model => model.IsHiddenInStore,
                            model_field => model_field.MapFrom(e => e.IsHiddenInStore));
        }
    }
}
