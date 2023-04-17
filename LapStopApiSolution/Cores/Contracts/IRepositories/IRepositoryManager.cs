using Contracts.IRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositories
{
    public interface IRepositoryManager
    {
        void Save();

        IBrandRepository Brand { get; }
        
        ICartRepository Card { get; }
        
        ICartItemRepository CardItem { get; }
        
        ICustomerAccountRepository CustomerAccount { get; }
        
        ICustomerRepository Customer { get; }

        IEmployeeAccountRepository EmployeeAccount { get; }

        IEmployeeGalleryRepository EmployeeGallery { get; }

        IEmployeeRepository Employee { get; }

        IEmployeeRoleRepository EmployeeRole { get; }

        IEmployeeStatusRepository EmployeeStatus { get; }

        IExportedInvoiceRepository ExportedInvoice { get; }

        IExportedInvoiceDetailRepository ExportedInvoiceDetail { get; }

        IImportedInvoiceRepository ImportedInvoice { get; }

        IImportedInvoiceDetailRepository ImportedInvoiceDetail { get; }

        IInvoiceStatusRepository InvoiceStatus { get; }

        IProductBrandRepository ProductBrand { get; }

        IProductGalleryRepository ProductGallery { get; }

        IProductRepository Product { get; }

        IProductStatusRepository ProductStatus { get; }

        ISalesOrderRepository SalesOrder { get; }

        ISalesOrderDetailRepository SalesOrderDetail { get; }

        ISalesOrderStatusRepository SalesOrderStatus { get; }
    }
}
