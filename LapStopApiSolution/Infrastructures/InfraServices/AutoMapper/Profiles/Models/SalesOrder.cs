using AutoMapper;

namespace InfraServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingSalesOrder()
        {
            Mapping_SalesOrder_To_SalesOrderDto();
        }

        private void Mapping_SalesOrder_To_SalesOrderDto()
        {
            CreateMap<SalesOrder, SalesOrderDto>()
                .ForMember(dto => dto.Id,
                           dto_field => dto_field.MapFrom(e => e.Id))
                .ForMember(dto => dto.CustomerId,
                           dto_field => dto_field.MapFrom(e => e.CustomerId))
                .ForMember(dto => dto.SalesOrderStatusId,
                           dto_field => dto_field.MapFrom(e => e.SalesOrderStatusId))
                .ForMember(dto => dto.OrderDate,
                           dto_field => dto_field.MapFrom(e => e.OrderDate))
                .ForMember(dto => dto.Address,
                           dto_field => dto_field.MapFrom(e => e.Address))
                .ForMember(dto => dto.Phone,
                           dto_field => dto_field.MapFrom(e => e.Phone))
                .ForMember(dto => dto.Total,
                           dto_field => dto_field.MapFrom(e => e.Total));
        }
    }
}
