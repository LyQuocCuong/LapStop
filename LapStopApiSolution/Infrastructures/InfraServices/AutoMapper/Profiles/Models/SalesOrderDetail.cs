using AutoMapper;

namespace InfraServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingSalesOrderDetail()
        {
            Mapping_SalesOrderDetail_To_SalesOrderDetailDto();
        }

        private void Mapping_SalesOrderDetail_To_SalesOrderDetailDto()
        {
            CreateMap<SalesOrderDetail, SalesOrderDetailDto>()
                .ForMember(dto => dto.Id,
                           dto_field => dto_field.MapFrom(e => e.Id))
                .ForMember(dto => dto.SalesOrderId,
                           dto_field => dto_field.MapFrom(e => e.SalesOrderId))
                .ForMember(dto => dto.ProductId,
                           dto_field => dto_field.MapFrom(e => e.ProductId))
                .ForMember(dto => dto.Quantity,
                           dto_field => dto_field.MapFrom(e => e.Quantity))
                .ForMember(dto => dto.SellingPrice,
                           dto_field => dto_field.MapFrom(e => e.SellingPrice))
                .ForMember(dto => dto.SubTotal,
                           dto_field => dto_field.MapFrom(e => e.SubTotal));
        }
    }
}
