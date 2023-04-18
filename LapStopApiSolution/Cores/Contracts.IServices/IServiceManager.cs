using Contracts.IServices.Models;

namespace Contracts.IServices
{
    public interface IServiceManager
    {
        IBrandService Brand { get; }

        ICartService Card { get; }

        ICartItemService CardItem { get; }

        ICustomerAccountService CustomerAccount { get; }

        ICustomerService Customer { get; }

        IEmployeeAccountService EmployeeAccount { get; }

        IEmployeeGalleryService EmployeeGallery { get; }

        IEmployeeService Employee { get; }

        IEmployeeRoleService EmployeeRole { get; }

        IEmployeeStatusService EmployeeStatus { get; }

        IExportedInvoiceService ExportedInvoice { get; }

        IExportedInvoiceDetailService ExportedInvoiceDetail { get; }

        IImportedInvoiceService ImportedInvoice { get; }

        IImportedInvoiceDetailService ImportedInvoiceDetail { get; }

        IInvoiceStatusService InvoiceStatus { get; }

        IProductBrandService ProductBrand { get; }

        IProductGalleryService ProductGallery { get; }

        IProductService Product { get; }

        IProductStatusService ProductStatus { get; }

        ISalesOrderService SalesOrder { get; }

        ISalesOrderDetailService SalesOrderDetail { get; }

        ISalesOrderStatusService SalesOrderStatus { get; }
    }
}
