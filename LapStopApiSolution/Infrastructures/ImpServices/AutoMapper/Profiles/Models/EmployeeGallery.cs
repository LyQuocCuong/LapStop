using AutoMapper;

namespace ImpServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingEmployeeGallery()
        {
            Mapping_EmployeeGallery_To_EmployeeGalleryDto();
        }

        private void Mapping_EmployeeGallery_To_EmployeeGalleryDto()
        {
            CreateMap<EmployeeGallery, EmployeeGalleryDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.EmployeeId,
                           dto_EmployeeId => dto_EmployeeId.MapFrom(e => e.EmployeeId))
                .ForMember(dto => dto.Title,
                           dto_Title => dto_Title.MapFrom(e => e.Title))
                .ForMember(dto => dto.Url,
                           dto_Url => dto_Url.MapFrom(e => e.Url));
        }
    }
}
