using AutoMapper;
using Domains.Models;
using DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperLib
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingEmployeeRole();
            MappingEmployeeStatus();
            MappingInvoiceStatus();
            MappingProductStatus();
            MappingSalesOrderStatus();
        }

        private void MappingEmployeeRole()
        {
            CreateMap<EmployeeRole, EmployeeRoleDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.Name,
                           dto_Name => dto_Name.MapFrom(e => e.Name))
                .ForMember(dto => dto.IsEnable,
                           dto_IsEnable => dto_IsEnable.MapFrom(e => e.IsEnable))
                .ForMember(dto => dto.IsRemoved,
                           dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));

        }

        private void MappingEmployeeStatus()
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

        private void MappingInvoiceStatus()
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

        private void MappingProductStatus()
        {
            CreateMap<ProductStatus, ProductStatusDto>()
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

        private void MappingSalesOrderStatus()
        {
            CreateMap<SalesOrderStatus, SalesOrderStatusDto>()
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
