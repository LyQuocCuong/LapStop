using Services.Models;

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

        public ServiceManager(ILogService logService,
                              IMappingService mappingService,
                              IRepositoryManager repositoryManager, 

                              IHateoasService<BrandDto, ExpandoForXmlObject> brandHateoasService,

                              IDataShaperService<EmployeeDto, ExpandoForXmlObject> dataShaperEmployee,
                              IDataShaperService<CustomerDto, ExpandoForXmlObject> dataShaperCustomer,
                              IDataShaperService<ProductDto, ExpandoForXmlObject> dataShaperProduct,
                              IDataShaperService<BrandDto, ExpandoForXmlObject> dataShaperBrand)
        {
            _brandService = new Lazy<IBrandService>(() => new BrandService(logService, mappingService, repositoryManager, brandHateoasService, dataShaperBrand));
            _cartService = new Lazy<ICartService>(() => new CartService(logService, mappingService, repositoryManager));
            _cartItemService = new Lazy<ICartItemService>(() => new CartItemService(logService, mappingService, repositoryManager));
            _customerAccountService = new Lazy<ICustomerAccountService>(() => new CustomerAccountService(logService, mappingService, repositoryManager));
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(logService, mappingService, repositoryManager, dataShaperCustomer));
            _employeeAccountService = new Lazy<IEmployeeAccountService>(() => new EmployeeAccountService(logService, mappingService, repositoryManager));
            _employeeGalleryService = new Lazy<IEmployeeGalleryService>(() => new EmployeeGalleryService(logService, mappingService, repositoryManager));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(logService, mappingService, repositoryManager, dataShaperEmployee));
            _employeeRoleService = new Lazy<IEmployeeRoleService>(() => new EmployeeRoleService(logService, mappingService, repositoryManager));
            _employeeStatusService = new Lazy<IEmployeeStatusService>(() => new EmployeeStatusService(logService, mappingService, repositoryManager));
            _exportedInvoiceService = new Lazy<IExportedInvoiceService>(() => new ExportedInvoiceService(logService, mappingService, repositoryManager));
            _exportedInvoiceDetailService = new Lazy<IExportedInvoiceDetailService>(() => new ExportedInvoiceDetailService(logService, mappingService, repositoryManager));
            _importedInvoiceService = new Lazy<IImportedInvoiceService>(() => new ImportedInvoiceService(logService, mappingService, repositoryManager));
            _importedInvoiceDetailService = new Lazy<IImportedInvoiceDetailService>(() => new ImportedInvoiceDetailService(logService, mappingService, repositoryManager));
            _invoiceStatusService = new Lazy<IInvoiceStatusService>(() => new InvoiceStatusService(logService, mappingService, repositoryManager));
            _productBrandService = new Lazy<IProductBrandService>(() => new ProductBrandService(logService, mappingService, repositoryManager));
            _productGalleryService = new Lazy<IProductGalleryService>(() => new ProductGalleryService(logService, mappingService, repositoryManager));
            _productService = new Lazy<IProductService>(() => new ProductService(logService, mappingService, repositoryManager, dataShaperProduct));
            _productStatusService = new Lazy<IProductStatusService>(() => new ProductStatusService(logService, mappingService, repositoryManager));
            _salesOrderService = new Lazy<ISalesOrderService>(() => new SalesOrderService(logService, mappingService, repositoryManager));
            _salesOrderDetailService = new Lazy<ISalesOrderDetailService>(() => new SalesOrderDetailService(logService, mappingService, repositoryManager));
            _salesOrderStatusService = new Lazy<ISalesOrderStatusService>(() => new SalesOrderStatusService(logService, mappingService, repositoryManager));
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
