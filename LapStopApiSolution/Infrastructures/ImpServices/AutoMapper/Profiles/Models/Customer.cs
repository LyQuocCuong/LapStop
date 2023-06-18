using AutoMapper;

namespace ImpServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingCustomer()
        {
            Mapping_Customer_To_CustomerDto();
            Mapping_CustomerForCreationDto_To_Customer();
            Mapping_CustomerForUpdateDto_To_Customer_Reverse();
        }

        private void Mapping_Customer_To_CustomerDto()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dto => dto.Id,
                            dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.FirstName,
                            dto_FirstName => dto_FirstName.MapFrom(e => e.FirstName))
                .ForMember(dto => dto.LastName,
                            dto_LastName => dto_LastName.MapFrom(e => e.LastName))
                .ForMember(dto => dto.Address,
                            dto_Address => dto_Address.MapFrom(e => e.Address))
                .ForMember(dto => dto.Phone,
                            dto_Phone => dto_Phone.MapFrom(e => e.Phone))
                .ForMember(dto => dto.IsRemoved,
                            dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));
        }

        private void Mapping_CustomerForCreationDto_To_Customer()
        {
            CreateMap<CustomerForCreationDto, Customer>()
                .ForMember(model => model.FirstName,
                           model_field => model_field.MapFrom(e => e.FirstName))
                .ForMember(model => model.LastName,
                           model_field => model_field.MapFrom(e => e.LastName))
                .ForMember(model => model.Address,
                           model_field => model_field.MapFrom(e => e.Address))
                .ForMember(model => model.Phone,
                           model_field => model_field.MapFrom(e => e.Phone));
        }

        private void Mapping_CustomerForUpdateDto_To_Customer_Reverse()
        {
            CreateMap<CustomerForUpdateDto, Customer>().ReverseMap()
                .ForMember(model => model.FirstName,
                            model_field => model_field.MapFrom(e => e.FirstName))
                .ForMember(model => model.LastName,
                            model_field => model_field.MapFrom(e => e.LastName))
                .ForMember(model => model.Address,
                            model_field => model_field.MapFrom(e => e.Address))
                .ForMember(model => model.Phone,
                            model_field => model_field.MapFrom(e => e.Phone));
        }

    }
}
