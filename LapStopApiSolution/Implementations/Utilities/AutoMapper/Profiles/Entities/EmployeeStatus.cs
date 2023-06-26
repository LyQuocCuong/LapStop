using AutoMapper;

namespace Utilities.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingEmployeeStatus()
        {
            Mapping_EmployeeStatus_To_EmployeeStatusDto();
        }

        private void Mapping_EmployeeStatus_To_EmployeeStatusDto()
        {
            CreateMap<EmployeeStatus, EmployeeStatusDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.Name,
                           dto_Name => dto_Name.MapFrom(e => e.Name))
                .ForMember(dto => dto.IsEnable,
                           dto_IsEnable => dto_IsEnable.MapFrom(e => e.IsEnable))
                .ForMember(dto => dto.IsRemoved,
                           dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));

        }
    }
}
