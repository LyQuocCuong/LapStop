using AutoMapper;
using Domains.Models;
using DTO.Output.Data;

namespace InfraServices.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        private void MappingInvoiceStatus()
        {
            Mapping_InvoiceStatus_To_InvoiceStatusDto();
        }

        private void Mapping_InvoiceStatus_To_InvoiceStatusDto()
        {
            CreateMap<InvoiceStatus, InvoiceStatusDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.Name,
                           dto_Name => dto_Name.MapFrom(e => e.Name))
                .ForMember(dto => dto.Description,
                           dto_Description => dto_Description.MapFrom(e => e.Description))
                .ForMember(dto => dto.IsEnable,
                           dto_IsEnable => dto_IsEnable.MapFrom(e => e.IsEnable))
                .ForMember(dto => dto.IsRemoved,
                           dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));

        }
    }
}
