using AutoMapper;

namespace Utilities.AutoMapper.Profiles
{
    public partial class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            MappingIdentEmployee();

            MappingBrand();

            MappingCart();
            MappingCartItem();

            MappingCustomer();
            MappingCustomerAccount();

            MappingEmployee();
            MappingEmployeeAccount();
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
    }
}