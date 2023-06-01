using AutoMapper;
using Domains.Models;
using DTO.Output.Data;

namespace AutoMapperLib.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingCart()
        {
            Mapping_Cart_To_CartDto();
        }

        private void Mapping_Cart_To_CartDto()
        {
            CreateMap<Cart, CartDto>()
                .ForMember(dto => dto.Id,
                            dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.CustomerId,
                            dto_CustomerId => dto_CustomerId.MapFrom(e => e.CustomerId))
                .ForMember(dto => dto.Total,
                            dto_Total => dto_Total.MapFrom(e => e.Total))
                .ForMember(dto => dto.IsRemoved,
                            dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));
        }

    }
}
