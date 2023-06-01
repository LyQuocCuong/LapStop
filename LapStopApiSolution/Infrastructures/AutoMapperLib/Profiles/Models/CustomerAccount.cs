using AutoMapper;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Output.Data;

namespace AutoMapperLib.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingCustomerAccount()
        {
            Mapping_CustomerAccount_To_CustomerAccountDto();
            Mapping_CustomerAccountForCreationDto_To_CustomerAccount();
            Mapping_CustomerAccountForUpdateDto_To_CustomerAccount();
        }

        private void Mapping_CustomerAccount_To_CustomerAccountDto()
        {
            CreateMap<CustomerAccount, CustomerAccountDto>()
                .ForMember(dto => dto.CustomerId,
                            dto_CustomerId => dto_CustomerId.MapFrom(e => e.CustomerId))
                .ForMember(dto => dto.Username,
                            dto_Username => dto_Username.MapFrom(e => e.Username))
                .ForMember(dto => dto.Password,
                            dto_Password => dto_Password.MapFrom(e => e.Password))
                .ForMember(dto => dto.IsActivate,
                            dto_IsActivate => dto_IsActivate.MapFrom(e => e.IsActivate))
                .ForMember(dto => dto.IsRemoved,
                            dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));
        }

        private void Mapping_CustomerAccountForCreationDto_To_CustomerAccount()
        {
            CreateMap<CustomerAccountForCreationDto, CustomerAccount>()
                .ForMember(model => model.Username,
                           model_field => model_field.MapFrom(e => e.Username))
                .ForMember(model => model.Password,
                           model_field => model_field.MapFrom(e => e.Password));
        }

        private void Mapping_CustomerAccountForUpdateDto_To_CustomerAccount()
        {
            CreateMap<CustomerAccountForUpdateDto, CustomerAccount>()
                .ForMember(model => model.Password,
                           model_field => model_field.MapFrom(e => e.Password));
        }
    }
}
