using AutoMapper;

namespace InfraServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingEmployeeAccount()
        {
            Mapping_EmployeeAccount_To_EmployeeAccountDto();
        }

        private void Mapping_EmployeeAccount_To_EmployeeAccountDto()
        {
            CreateMap<EmployeeAccount, EmployeeAccountDto>()
                .ForMember(dto => dto.EmployeeId,
                           dto_Id => dto_Id.MapFrom(e => e.EmployeeId))
                .ForMember(dto => dto.Username,
                           dto_Username => dto_Username.MapFrom(e => e.Username))
                .ForMember(dto => dto.Password,
                           dto_Password => dto_Password.MapFrom(e => e.Password))
                .ForMember(dto => dto.IsActivate,
                           dto_IsActivate => dto_IsActivate.MapFrom(e => e.IsActivate));
        }

    }
}
