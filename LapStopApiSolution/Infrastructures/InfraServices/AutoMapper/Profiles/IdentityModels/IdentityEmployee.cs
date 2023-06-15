using AutoMapper;
using Domains.IdentityModels;

namespace InfraServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingIdentEmployee()
        {
            Mapping_EmployeeForRegistrationDto_To_IdentityEmployee();
        }

        private void Mapping_EmployeeForRegistrationDto_To_IdentityEmployee()
        {
            CreateMap<EmployeeForRegistrationDto, IdentEmployee>()
                .ForMember(model => model.FirstName,
                           model_field => model_field.MapFrom(e => e.FirstName))
                .ForMember(model => model.LastName,
                           model_field => model_field.MapFrom(e => e.LastName))
                .ForMember(model => model.UserName,
                           model_field => model_field.MapFrom(e => e.UserName))
                .ForMember(model => model.PasswordHash,
                           model_field => model_field.MapFrom(e => e.Password))
                .ForMember(model => model.Email,
                           model_field => model_field.MapFrom(e => e.Email))
                .ForMember(model => model.PhoneNumber,
                           model_field => model_field.MapFrom(e => e.PhoneNumber));
        }
    }
}
