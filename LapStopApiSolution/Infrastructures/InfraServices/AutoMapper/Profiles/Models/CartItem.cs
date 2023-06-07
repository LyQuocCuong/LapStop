using AutoMapper;

namespace InfraServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingCartItem()
        {
            Mapping_CartItem_To_CartItemDto();
        }

        private void Mapping_CartItem_To_CartItemDto()
        {
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.CartId,
                           dto_CartId => dto_CartId.MapFrom(e => e.CartId))
                .ForMember(dto => dto.ProductId,
                           dto_ProductId => dto_ProductId.MapFrom(e => e.ProductId))
                .ForMember(dto => dto.Quantity,
                           dto_Quantity => dto_Quantity.MapFrom(e => e.Quantity))
                .ForMember(dto => dto.SellingPrice,
                           dto_SellingPrice => dto_SellingPrice.MapFrom(e => e.SellingPrice))
                .ForMember(dto => dto.SubTotal,
                           dto_SubTotal => dto_SubTotal.MapFrom(e => e.SubTotal))
                .ForMember(dto => dto.IsRemoved,
                           dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));

        }
    }
}
