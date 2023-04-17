using Contracts.IRepositories;
using Contracts.IRepositories.Models;
using Contracts.IServices;
using Contracts.IServices.Models;
using Entities.Context;
using Repositories;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<ICartService> _cartService;
        private readonly Lazy<ICartItemService> _cartItemService;
        private readonly Lazy<ICustomerAccountService> _customerAccountService;
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IEmployeeAccountService> _employeeAccountService;
        private readonly Lazy<IEmployeeGalleryService> _employeeGalleryService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IEmployeeRoleService> _employeeRoleService;
        private readonly Lazy<IEmployeeStatusService> _employeeStatusService;
        private readonly Lazy<IExportedInvoiceService> _exportedInvoiceService;
        private readonly Lazy<IExportedInvoiceDetailService> _exportedInvoiceDetailService;
        private readonly Lazy<IImportedInvoiceService> _importedInvoiceService;
        private readonly Lazy<IImportedInvoiceDetailService> _importedInvoiceDetailService;
        private readonly Lazy<IInvoiceStatusService> _invoiceStatusService;
        private readonly Lazy<IProductBrandService> _productBrandService;
        private readonly Lazy<IProductGalleryService> _productGalleryService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IProductStatusService> _productStatusService;
        private readonly Lazy<ISalesOrderService> _salesOrderService;
        private readonly Lazy<ISalesOrderDetailService> _salesOrderDetailService;
        private readonly Lazy<ISalesOrderStatusService> _salesOrderStatusService;

        public ServiceManager(LapStopContext context)
        {
            _brandService = new Lazy<IBrandService>(() => new BrandService(context));
            _cartService = new Lazy<ICartService>(() => new CartService(context));
            _cartItemService = new Lazy<ICartItemService>(() => new CartItemService(context));
            _customerAccountService = new Lazy<ICustomerAccountService>(() => new CustomerAccountService(context));
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(context));
            _employeeAccountService = new Lazy<IEmployeeAccountService>(() => new EmployeeAccountService(context));
            _employeeGalleryService = new Lazy<IEmployeeGalleryService>(() => new EmployeeGalleryService(context));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(context));
            _employeeRoleService = new Lazy<IEmployeeRoleService>(() => new EmployeeRoleService(context));
            _employeeStatusService = new Lazy<IEmployeeStatusService>(() => new EmployeeStatusService(context));
            _exportedInvoiceService = new Lazy<IExportedInvoiceService>(() => new ExportedInvoiceService(context));
            _exportedInvoiceDetailService = new Lazy<IExportedInvoiceDetailService>(() => new ExportedInvoiceDetailService(context));
            _importedInvoiceService = new Lazy<IImportedInvoiceService>(() => new ImportedInvoiceService(context));
            _importedInvoiceDetailService = new Lazy<IImportedInvoiceDetailService>(() => new ImportedInvoiceDetailService(context));
            _invoiceStatusService = new Lazy<IInvoiceStatusService>(() => new InvoiceStatusService(context));
            _productBrandService = new Lazy<IProductBrandService>(() => new ProductBrandService(context));
            _productGalleryService = new Lazy<IProductGalleryService>(() => new ProductGalleryService(context));
            _productService = new Lazy<IProductService>(() => new ProductService(context));
            _productStatusService = new Lazy<IProductStatusService>(() => new ProductStatusService(context));
            _salesOrderService = new Lazy<ISalesOrderService>(() => new SalesOrderService(context));
            _salesOrderDetailService = new Lazy<ISalesOrderDetailService>(() => new SalesOrderDetailService(context));
            _salesOrderStatusService = new Lazy<ISalesOrderStatusService>(() => new SalesOrderStatusService(context));
        }

        public IBrandService Brand => _brandService.Value;

        public ICartService Card => _cartService.Value;

        public ICartItemService CardItem => _cartItemService.Value;

        public ICustomerAccountService CustomerAccount => _customerAccountService.Value;

        public ICustomerService Customer => _customerService.Value;

        public IEmployeeAccountService EmployeeAccount => _employeeAccountService.Value;

        public IEmployeeGalleryService EmployeeGallery => _employeeGalleryService.Value;

        public IEmployeeService Employee => _employeeService.Value;

        public IEmployeeRoleService EmployeeRole => _employeeRoleService.Value;

        public IEmployeeStatusService EmployeeStatus => _employeeStatusService.Value;

        public IExportedInvoiceService ExportedInvoice => _exportedInvoiceService.Value;

        public IExportedInvoiceDetailService ExportedInvoiceDetail => _exportedInvoiceDetailService.Value;

        public IImportedInvoiceService ImportedInvoice => _importedInvoiceService.Value;

        public IImportedInvoiceDetailService ImportedInvoiceDetail => _importedInvoiceDetailService.Value;

        public IInvoiceStatusService InvoiceStatus => _invoiceStatusService.Value;

        public IProductBrandService ProductBrand => _productBrandService.Value;

        public IProductGalleryService ProductGallery => _productGalleryService.Value;

        public IProductService Product => _productService.Value;

        public IProductStatusService ProductStatus => _productStatusService.Value;

        public ISalesOrderService SalesOrder => _salesOrderService.Value;

        public ISalesOrderDetailService SalesOrderDetail => _salesOrderDetailService.Value;

        public ISalesOrderStatusService SalesOrderStatus => _salesOrderStatusService.Value;
    }
}
