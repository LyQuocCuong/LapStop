using Contracts.IRepositories.Models;
using Contracts.IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
