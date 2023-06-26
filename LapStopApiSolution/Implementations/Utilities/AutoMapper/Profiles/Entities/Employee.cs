using AutoMapper;

namespace Utilities.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingEmployee()
        {
            Mapping_Employee_To_EmployeeDto();
            Mapping_EmployeeForCreationDto_To_Employee();
            Mapping_EmployeeForUpdateDto_To_Employee_Reverse();
        }

        private void Mapping_Employee_To_EmployeeDto()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.Id,
                            dto_field => dto_field.MapFrom(e => e.Id))
                .ForMember(dto => dto.EmployeeRoleId,
                            dto_field => dto_field.MapFrom(e => e.EmployeeRoleId))
                .ForMember(dto => dto.EmployeeRoleName,
                            dto_field => dto_field.MapFrom(e => e.EmployeeRole != null ? e.EmployeeRole.Name : ""))
                .ForMember(dto => dto.EmployeeStatusId,
                            dto_field => dto_field.MapFrom(e => e.EmployeeStatusId))
                .ForMember(dto => dto.EmployeeStatusName,
                            dto_field => dto_field.MapFrom(e => e.EmployeeStatus != null ? e.EmployeeStatus.Name : ""))
                .ForMember(dto => dto.EmployeeCode,
                            dto_field => dto_field.MapFrom(e => e.EmployeeCode))
                .ForMember(dto => dto.FirstName,
                            dto_field => dto_field.MapFrom(e => e.FirstName))
                .ForMember(dto => dto.LastName,
                            dto_field => dto_field.MapFrom(e => e.LastName))
                .ForMember(dto => dto.FullName,
                            dto_field => dto_field.MapFrom(e => string.Concat(e.FirstName, " ", e.LastName)))
                .ForMember(dto => dto.Email,
                            dto_field => dto_field.MapFrom(e => e.Email))
                .ForMember(dto => dto.DOB,
                            dto_field => dto_field.MapFrom(e => e.DOB))
                .ForMember(dto => dto.Email,
                            dto_field => dto_field.MapFrom(e => e.Email))
                .ForMember(dto => dto.Phone,
                            dto_field => dto_field.MapFrom(e => e.Phone))
                .ForMember(dto => dto.IsRemoved,
                            dto_field => dto_field.MapFrom(e => e.IsRemoved))
                .ForMember(dto => dto.AvatarUrl,
                            dto_field => dto_field.MapFrom(e => e.AvatarUrl))
                .ForMember(dto => dto.CreatedDate,
                            dto_field => dto_field.MapFrom(e => e.CreatedDate))
                .ForMember(dto => dto.UpdatedDate,
                            dto_field => dto_field.MapFrom(e => e.UpdatedDate));
        }

        private void Mapping_EmployeeForCreationDto_To_Employee()
        {
            CreateMap<EmployeeForCreationDto, Employee>()
                .ForMember(model => model.EmployeeRoleId,
                           model_field => model_field.MapFrom(e => e.EmployeeRoleId))
                .ForMember(model => model.EmployeeStatusId,
                           model_field => model_field.MapFrom(e => e.EmployeeStatusId))
                .ForMember(model => model.EmployeeCode,
                           model_field => model_field.MapFrom(e => e.EmployeeCode))
                .ForMember(model => model.FirstName,
                           model_field => model_field.MapFrom(e => e.FirstName))
                .ForMember(model => model.LastName,
                           model_field => model_field.MapFrom(e => e.LastName))
                .ForMember(model => model.IsMale,
                           model_field => model_field.MapFrom(e => e.IsMale))
                .ForMember(model => model.DOB,
                           model_field => model_field.MapFrom(e => e.DOB))
                .ForMember(model => model.Address,
                           model_field => model_field.MapFrom(e => e.Address))
                .ForMember(model => model.Email,
                           model_field => model_field.MapFrom(e => e.Email))
                .ForMember(model => model.Phone,
                           model_field => model_field.MapFrom(e => e.Phone))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl));
        }

        private void Mapping_EmployeeForUpdateDto_To_Employee_Reverse()
        {
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap()
                .ForMember(model => model.EmployeeRoleId,
                           model_field => model_field.MapFrom(e => e.EmployeeRoleId))
                .ForMember(model => model.EmployeeStatusId,
                           model_field => model_field.MapFrom(e => e.EmployeeStatusId))
                .ForMember(model => model.EmployeeCode,
                           model_field => model_field.MapFrom(e => e.EmployeeCode))
                .ForMember(model => model.FirstName,
                           model_field => model_field.MapFrom(e => e.FirstName))
                .ForMember(model => model.LastName,
                           model_field => model_field.MapFrom(e => e.LastName))
                .ForMember(model => model.IsMale,
                           model_field => model_field.MapFrom(e => e.IsMale))
                .ForMember(model => model.DOB,
                           model_field => model_field.MapFrom(e => e.DOB))
                .ForMember(model => model.Address,
                           model_field => model_field.MapFrom(e => e.Address))
                .ForMember(model => model.Email,
                           model_field => model_field.MapFrom(e => e.Email))
                .ForMember(model => model.Phone,
                           model_field => model_field.MapFrom(e => e.Phone))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl));
        }
    }
}
