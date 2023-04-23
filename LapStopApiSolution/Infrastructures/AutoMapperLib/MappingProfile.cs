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
            MappingBrand();
            MappingCart();
            MappingCartItem();
            MappingCustomerAccount();
            MappingCustomer();
            MappingEmployeeRole();
            MappingEmployeeStatus();
            MappingInvoiceStatus();
            MappingProductStatus();
            MappingSalesOrderStatus();
        }

        private void MappingBrand()
        {
            CreateMap<Brand, BrandDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.Name,
                           dto_Name => dto_Name.MapFrom(e => e.Name))
                .ForMember(dto => dto.Description,
                           dto_Description => dto_Description.MapFrom(e => e.Description))
                .ForMember(dto => dto.AvatarUrl,
                           dto_AvatarUrl => dto_AvatarUrl.MapFrom(e => e.AvatarUrl))
                .ForMember(dto => dto.IsRemoved,
                           dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));

        }

        private void MappingCart()
        {
            CreateMap<Cart, CartDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.CustomerId,
                           dto_CustomerId => dto_CustomerId.MapFrom(e => e.CustomerId))
                .ForMember(dto => dto.Total,
                           dto_Total => dto_Total.MapFrom(e => e.Total))
                .ForMember(dto => dto.IsRemoved,
                           dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));

        }

        private void MappingCartItem()
        {
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.CartId,
                           dto_CartId => dto_CartId.MapFrom(e => e.CartId))
                .ForMember(dto => dto.ProductId,
                           dto_ProductId => dto_ProductId.MapFrom(e => e.ProductId))
                .ForMember(dto => dto.Quantity,
                           dto_Quantity => dto_Quantity.MapFrom(e => e.Quantity))
                .ForMember(dto => dto.SellingPrice,
                           dto_SellingPrice => dto_SellingPrice.MapFrom(e => e.SellingPrice))
                .ForMember(dto => dto.SubTotal,
                           dto_SubTotal => dto_SubTotal.MapFrom(e => e.SubTotal))
                .ForMember(dto => dto.IsRemoved,
                           dto_IsRemoved => dto_IsRemoved.MapFrom(e => e.IsRemoved));

        }

        private void MappingCustomerAccount()
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

        private void MappingCustomer()
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
