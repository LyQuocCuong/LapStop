using Contracts.IServices.Managers;
using Services.Entities;

namespace Services.Managers
{
    public sealed class EntityServiceManager : IEntityServiceManager
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

        public EntityServiceManager(ServiceParams serviceParams)
        {
            _brandService = new Lazy<IBrandService>(() => new BrandService(serviceParams));
            _cartService = new Lazy<ICartService>(() => new CartService(serviceParams));
            _cartItemService = new Lazy<ICartItemService>(() => new CartItemService(serviceParams));
            _customerAccountService = new Lazy<ICustomerAccountService>(() => new CustomerAccountService(serviceParams));
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(serviceParams));
            _employeeAccountService = new Lazy<IEmployeeAccountService>(() => new EmployeeAccountService(serviceParams));
            _employeeGalleryService = new Lazy<IEmployeeGalleryService>(() => new EmployeeGalleryService(serviceParams));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(serviceParams));
            _employeeRoleService = new Lazy<IEmployeeRoleService>(() => new EmployeeRoleService(serviceParams));
            _employeeStatusService = new Lazy<IEmployeeStatusService>(() => new EmployeeStatusService(serviceParams));
            _exportedInvoiceService = new Lazy<IExportedInvoiceService>(() => new ExportedInvoiceService(serviceParams));
            _exportedInvoiceDetailService = new Lazy<IExportedInvoiceDetailService>(() => new ExportedInvoiceDetailService(serviceParams));
            _importedInvoiceService = new Lazy<IImportedInvoiceService>(() => new ImportedInvoiceService(serviceParams));
            _importedInvoiceDetailService = new Lazy<IImportedInvoiceDetailService>(() => new ImportedInvoiceDetailService(serviceParams));
            _invoiceStatusService = new Lazy<IInvoiceStatusService>(() => new InvoiceStatusService(serviceParams));
            _productBrandService = new Lazy<IProductBrandService>(() => new ProductBrandService(serviceParams));
            _productGalleryService = new Lazy<IProductGalleryService>(() => new ProductGalleryService(serviceParams));
            _productService = new Lazy<IProductService>(() => new ProductService(serviceParams));
            _productStatusService = new Lazy<IProductStatusService>(() => new ProductStatusService(serviceParams));
            _salesOrderService = new Lazy<ISalesOrderService>(() => new SalesOrderService(serviceParams));
            _salesOrderDetailService = new Lazy<ISalesOrderDetailService>(() => new SalesOrderDetailService(serviceParams));
            _salesOrderStatusService = new Lazy<ISalesOrderStatusService>(() => new SalesOrderStatusService(serviceParams));
        }

        public IBrandService Brand => _brandService.Value;

        public ICartService Cart => _cartService.Value;

        public ICartItemService CartItem => _cartItemService.Value;

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
