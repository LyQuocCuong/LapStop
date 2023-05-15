using AutoMapper;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Output.Data;
using System.Reflection;

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

            MappingEmployeeAccount();
            MappingEmployee();
            MappingEmployeeGallery();
            MappingEmployeeRole();
            MappingEmployeeStatus();

            MappingInvoiceStatus();

            MappingProduct();
            MappingProductBrand();
            MappingProductGallery();
            MappingProductStatus();

            MappingSalesOrder();
            MappingSalesOrderDetail();
            MappingSalesOrderStatus();
        }

        private void MappingBrand()
        {
            #region Brand --> BrandDto
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
            #endregion

            #region BrandCreationDto --> Brand
            CreateMap<BrandForCreationDto, Brand>()
                .ForMember(model => model.Name,
                           model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                           model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl));
            #endregion

            #region BrandForUpdateDto <--> Brand
            CreateMap<BrandForUpdateDto, Brand>().ReverseMap()
                .ForMember(model => model.Name,
                           model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                           model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl));
            #endregion
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
            #region  CustomerAccount --> CustomerAccountDto
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
            #endregion

            #region CustomerAccountForCreationDto --> CustomerAccount
            CreateMap<CustomerAccountForCreationDto, CustomerAccount>()
                .ForMember(model => model.Username,
                           model_field => model_field.MapFrom(e => e.Username))
                .ForMember(model => model.Password,
                           model_field => model_field.MapFrom(e => e.Password));
            #endregion

            #region CustomerAccountForUpdateDto --> CustomerAccount
            CreateMap<CustomerAccountForUpdateDto, CustomerAccount>()
                .ForMember(model => model.Password,
                           model_field => model_field.MapFrom(e => e.Password));
            #endregion

        }

        private void MappingCustomer()
        {
            #region Customer --> CustomerDto
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
            #endregion

            #region CustomerForCreationDto --> Customer
            CreateMap<CustomerForCreationDto, Customer>()
                .ForMember(model => model.FirstName,
                           model_field => model_field.MapFrom(e => e.FirstName))
                .ForMember(model => model.LastName,
                           model_field => model_field.MapFrom(e => e.LastName))
                .ForMember(model => model.Address,
                           model_field => model_field.MapFrom(e => e.Address))
                .ForMember(model => model.Phone,
                           model_field => model_field.MapFrom(e => e.Phone));
            #endregion

            #region CustomerForUpdateDto <--> Customer
            CreateMap<CustomerForUpdateDto, Customer>().ReverseMap()
                .ForMember(model => model.FirstName,
                           model_field => model_field.MapFrom(e => e.FirstName))
                .ForMember(model => model.LastName,
                           model_field => model_field.MapFrom(e => e.LastName))
                .ForMember(model => model.Address,
                           model_field => model_field.MapFrom(e => e.Address))
                .ForMember(model => model.Phone,
                           model_field => model_field.MapFrom(e => e.Phone));
            #endregion
        }

        private void MappingEmployeeAccount()
        {
            #region EmployeeAccount --> EmployeeAccountDto
            CreateMap<EmployeeAccount, EmployeeAccountDto>()
                .ForMember(dto => dto.EmployeeId,
                           dto_Id => dto_Id.MapFrom(e => e.EmployeeId))
                .ForMember(dto => dto.Username,
                           dto_Username => dto_Username.MapFrom(e => e.Username))
                .ForMember(dto => dto.Password,
                           dto_Password => dto_Password.MapFrom(e => e.Password))
                .ForMember(dto => dto.IsActivate,
                           dto_IsActivate => dto_IsActivate.MapFrom(e => e.IsActivate));
            #endregion
        }

        private void MappingEmployee()
        {
            #region Employee --> EmployeeDto
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
                           dto_field => dto_field.MapFrom(e => String.Concat(e.FirstName, " ", e.LastName)))
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
            #endregion

            #region EmployeeForCreationDto --> Employee
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
            #endregion

            #region EmployeeForUpdateDto <--> Employee
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
            #endregion

        }

        private void MappingEmployeeGallery()
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

        private void MappingProductBrand()
        {
            CreateMap<ProductBrand, ProductBrandDto>()
                .ForMember(dto => dto.ProductId,
                           dto_ProductId => dto_ProductId.MapFrom(e => e.ProductId))
                .ForMember(dto => dto.BrandId,
                           dto_BrandId => dto_BrandId.MapFrom(e => e.BrandId));
        }

        private void MappingProduct()
        {
            #region Product --> ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.ProductStatusId,
                           dto_ProductStatusId => dto_ProductStatusId.MapFrom(e => e.ProductStatusId))
                .ForMember(dto => dto.ProductStatusName,
                           dto_ProductStatusName => dto_ProductStatusName.MapFrom(e => e.ProductStatus != null ? e.ProductStatus.Name : ""))
                .ForMember(dto => dto.ProductCode,
                           dto_ProductCode => dto_ProductCode.MapFrom(e => e.ProductCode))
                .ForMember(dto => dto.Name,
                           dto_Name => dto_Name.MapFrom(e => e.Name))
                .ForMember(dto => dto.Description,
                           dto_Description => dto_Description.MapFrom(e => e.Description))
                .ForMember(dto => dto.AvatarUrl,
                           dto_AvatarUrl => dto_AvatarUrl.MapFrom(e => e.AvatarUrl))
                .ForMember(dto => dto.OriginalPrice,
                           dto_OriginalPrice => dto_OriginalPrice.MapFrom(e => e.OriginalPrice))
                .ForMember(dto => dto.CurrentPrice,
                           dto_CurrentPrice => dto_CurrentPrice.MapFrom(e => e.CurrentPrice))
                .ForMember(dto => dto.SellingPrice,
                           dto_SellingPrice => dto_SellingPrice.MapFrom(e => e.SellingPrice))
                .ForMember(dto => dto.IsHiddenInStore,
                           dto_IsHiddenInStore => dto_IsHiddenInStore.MapFrom(e => e.IsHiddenInStore));
            #endregion

            #region ProductForCreationDto --> Product
            CreateMap<ProductForCreationDto, Product>()
                .ForMember(model => model.ProductStatusId,
                           model_field => model_field.MapFrom(e => e.ProductStatusId))
                .ForMember(model => model.ProductCode,
                           model_field => model_field.MapFrom(e => e.ProductCode))
                .ForMember(model => model.Name,
                           model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                           model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl))
                .ForMember(model => model.OriginalPrice,
                           model_field => model_field.MapFrom(e => e.OriginalPrice))
                .ForMember(model => model.CurrentPrice,
                           model_field => model_field.MapFrom(e => e.CurrentPrice))
                .ForMember(model => model.SellingPrice,
                           model_field => model_field.MapFrom(e => e.SellingPrice))
                .ForMember(model => model.IsHiddenInStore,
                           model_field => model_field.MapFrom(e => e.IsHiddenInStore));
            #endregion

            #region ProductForUpdateDto --> Product
            CreateMap<ProductForUpdateDto, Product>().ReverseMap()
                .ForMember(model => model.ProductStatusId,
                           model_field => model_field.MapFrom(e => e.ProductStatusId))
                .ForMember(model => model.ProductCode,
                           model_field => model_field.MapFrom(e => e.ProductCode))
                .ForMember(model => model.Name,
                           model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                           model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl))
                .ForMember(model => model.OriginalPrice,
                           model_field => model_field.MapFrom(e => e.OriginalPrice))
                .ForMember(model => model.CurrentPrice,
                           model_field => model_field.MapFrom(e => e.CurrentPrice))
                .ForMember(model => model.SellingPrice,
                           model_field => model_field.MapFrom(e => e.SellingPrice))
                .ForMember(model => model.IsHiddenInStore,
                           model_field => model_field.MapFrom(e => e.IsHiddenInStore));
            #endregion

            #region ProductForBulkUpdateDto --> Product
            CreateMap<ProductForBulkUpdateDto, Product>().ReverseMap()
                .ForMember(model => model.Id,
                           model_field => model_field.MapFrom(e => e.Id))
                .ForMember(model => model.ProductStatusId,
                           model_field => model_field.MapFrom(e => e.ProductStatusId))
                .ForMember(model => model.ProductCode,
                           model_field => model_field.MapFrom(e => e.ProductCode))
                .ForMember(model => model.Name,
                           model_field => model_field.MapFrom(e => e.Name))
                .ForMember(model => model.Description,
                           model_field => model_field.MapFrom(e => e.Description))
                .ForMember(model => model.AvatarUrl,
                           model_field => model_field.MapFrom(e => e.AvatarUrl))
                .ForMember(model => model.OriginalPrice,
                           model_field => model_field.MapFrom(e => e.OriginalPrice))
                .ForMember(model => model.CurrentPrice,
                           model_field => model_field.MapFrom(e => e.CurrentPrice))
                .ForMember(model => model.SellingPrice,
                           model_field => model_field.MapFrom(e => e.SellingPrice))
                .ForMember(model => model.IsHiddenInStore,
                           model_field => model_field.MapFrom(e => e.IsHiddenInStore));
            #endregion
        }

        private void MappingProductGallery()
        {
            CreateMap<ProductGallery, ProductGalleryDto>()
                .ForMember(dto => dto.Id,
                           dto_Id => dto_Id.MapFrom(e => e.Id))
                .ForMember(dto => dto.ProductId,
                           dto_ProductId => dto_ProductId.MapFrom(e => e.ProductId))
                .ForMember(dto => dto.Title,
                           dto_Title => dto_Title.MapFrom(e => e.Title))
                .ForMember(dto => dto.Url,
                           dto_Url => dto_Url.MapFrom(e => e.Url));
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

        private void MappingSalesOrder()
        {
            CreateMap<SalesOrder, SalesOrderDto>()
                .ForMember(dto => dto.Id,
                           dto_field => dto_field.MapFrom(e => e.Id))
                .ForMember(dto => dto.CustomerId,
                           dto_field => dto_field.MapFrom(e => e.CustomerId))
                .ForMember(dto => dto.SalesOrderStatusId,
                           dto_field => dto_field.MapFrom(e => e.SalesOrderStatusId))
                .ForMember(dto => dto.OrderDate,
                           dto_field => dto_field.MapFrom(e => e.OrderDate))
                .ForMember(dto => dto.Address,
                           dto_field => dto_field.MapFrom(e => e.Address))
                .ForMember(dto => dto.Phone,
                           dto_field => dto_field.MapFrom(e => e.Phone))
                .ForMember(dto => dto.Total,
                           dto_field => dto_field.MapFrom(e => e.Total));
        }

        private void MappingSalesOrderDetail()
        {
            CreateMap<SalesOrderDetail, SalesOrderDetailDto>()
                .ForMember(dto => dto.Id,
                           dto_field => dto_field.MapFrom(e => e.Id))
                .ForMember(dto => dto.SalesOrderId,
                           dto_field => dto_field.MapFrom(e => e.SalesOrderId))
                .ForMember(dto => dto.ProductId,
                           dto_field => dto_field.MapFrom(e => e.ProductId))
                .ForMember(dto => dto.Quantity,
                           dto_field => dto_field.MapFrom(e => e.Quantity))
                .ForMember(dto => dto.SellingPrice,
                           dto_field => dto_field.MapFrom(e => e.SellingPrice))
                .ForMember(dto => dto.SubTotal,
                           dto_field => dto_field.MapFrom(e => e.SubTotal));
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
