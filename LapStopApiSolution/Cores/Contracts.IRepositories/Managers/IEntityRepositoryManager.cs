using Contracts.IRepositories.Entities;

namespace Contracts.IRepositories.Managers
{
    public interface IEntityRepositoryManager
    {
        IBrandRepository Brand { get; }

        ICartRepository Cart { get; }

        ICartItemRepository CartItem { get; }

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
