using Contracts.IRepositories;
using Contracts.IRepositories.Models;
using Entities.Context;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class RepositoryManager : IRepositoryManager, IDisposable
    {
        private readonly LapStopContext _context;

        private readonly Lazy<IBrandRepository> _brandRepository;
        private readonly Lazy<ICartRepository> _cartRepository;
        private readonly Lazy<ICartItemRepository> _cartItemRepository;
        private readonly Lazy<ICustomerAccountRepository> _customerAccountRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IEmployeeAccountRepository> _employeeAccountRepository;
        private readonly Lazy<IEmployeeGalleryRepository> _employeeGalleryRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IEmployeeRoleRepository> _employeeRoleRepository;
        private readonly Lazy<IEmployeeStatusRepository> _employeeStatusRepository;
        private readonly Lazy<IExportedInvoiceRepository> _exportedInvoiceRepository;
        private readonly Lazy<IExportedInvoiceDetailRepository> _exportedInvoiceDetailRepository;
        private readonly Lazy<IImportedInvoiceRepository> _importedInvoiceRepository;
        private readonly Lazy<IImportedInvoiceDetailRepository> _importedInvoiceDetailRepository;
        private readonly Lazy<IInvoiceStatusRepository> _invoiceStatusRepository;
        private readonly Lazy<IProductBrandRepository> _productBrandRepository;
        private readonly Lazy<IProductGalleryRepository> _productGalleryRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IProductStatusRepository> _productStatusRepository;
        private readonly Lazy<ISalesOrderRepository> _salesOrderRepository;
        private readonly Lazy<ISalesOrderDetailRepository> _salesOrderDetailRepository;
        private readonly Lazy<ISalesOrderStatusRepository> _salesOrderStatusRepository;

        public RepositoryManager(LapStopContext context)
        {
            _context = context;

            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(context));
            _cartRepository = new Lazy<ICartRepository>(() => new CartRepository(context));
            _cartItemRepository = new Lazy<ICartItemRepository>(() => new CartItemRepository(context));
            _customerAccountRepository = new Lazy<ICustomerAccountRepository>(() => new CustomerAccountRepository(context));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
            _employeeAccountRepository = new Lazy<IEmployeeAccountRepository>(()  => new EmployeeAccountRepository(context));
            _employeeGalleryRepository = new Lazy<IEmployeeGalleryRepository>(()  => new EmployeeGalleryRepository(context));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(context));
            _employeeRoleRepository = new Lazy<IEmployeeRoleRepository>(() => new EmployeeRoleRepository(context));
            _employeeStatusRepository = new Lazy<IEmployeeStatusRepository>(() => new EmployeeStatusRepository(context));
            _exportedInvoiceRepository = new Lazy<IExportedInvoiceRepository>(() => new ExportedInvoiceRepository(context));
            _exportedInvoiceDetailRepository = new Lazy<IExportedInvoiceDetailRepository>(() => new ExportedInvoiceDetailRepository(context));
            _importedInvoiceRepository = new Lazy<IImportedInvoiceRepository>(() => new ImportedInvoiceRepository(context));
            _importedInvoiceDetailRepository = new Lazy<IImportedInvoiceDetailRepository> (() => new ImportedInvoiceDetailRepository(context));
            _invoiceStatusRepository = new Lazy<IInvoiceStatusRepository>(()  => new InvoiceStatusRepository(context));
            _productBrandRepository = new Lazy<IProductBrandRepository>(()  => new ProductBrandRepository(context));
            _productGalleryRepository = new Lazy<IProductGalleryRepository> (() => new ProductGalleryRepository(context));
            _productRepository = new Lazy<IProductRepository>(()  => new ProductRepository(context));
            _productStatusRepository = new Lazy<IProductStatusRepository>(()  => new ProductStatusRepository(context));
            _salesOrderRepository = new Lazy<ISalesOrderRepository>(()  => new SalesOrderRepository(context));
            _salesOrderDetailRepository = new Lazy<ISalesOrderDetailRepository>(()  => new SalesOrderDetailRepository(context));
            _salesOrderStatusRepository = new Lazy<ISalesOrderStatusRepository>(()  => new SalesOrderStatusRepository(context));
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IBrandRepository Brand => _brandRepository.Value;

        public ICartRepository Card => _cartRepository.Value;

        public ICartItemRepository CardItem => _cartItemRepository.Value;

        public ICustomerAccountRepository CustomerAccount => _customerAccountRepository.Value;

        public ICustomerRepository Customer => _customerRepository.Value;

        public IEmployeeAccountRepository EmployeeAccount => _employeeAccountRepository.Value;

        public IEmployeeGalleryRepository EmployeeGallery => _employeeGalleryRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IEmployeeRoleRepository EmployeeRole => _employeeRoleRepository.Value;

        public IEmployeeStatusRepository EmployeeStatus => _employeeStatusRepository.Value;

        public IExportedInvoiceRepository ExportedInvoice => _exportedInvoiceRepository.Value;

        public IExportedInvoiceDetailRepository ExportedInvoiceDetail => _exportedInvoiceDetailRepository.Value;

        public IImportedInvoiceRepository ImportedInvoice => _importedInvoiceRepository.Value;

        public IImportedInvoiceDetailRepository ImportedInvoiceDetail => _importedInvoiceDetailRepository.Value;

        public IInvoiceStatusRepository InvoiceStatus => _invoiceStatusRepository.Value;

        public IProductBrandRepository ProductBrand => _productBrandRepository.Value;

        public IProductGalleryRepository ProductGallery => _productGalleryRepository.Value;

        public IProductRepository Product => _productRepository.Value;

        public IProductStatusRepository ProductStatus => _productStatusRepository.Value;

        public ISalesOrderRepository SalesOrder => _salesOrderRepository.Value;

        public ISalesOrderDetailRepository SalesOrderDetail => _salesOrderDetailRepository.Value;

        public ISalesOrderStatusRepository SalesOrderStatus => _salesOrderStatusRepository.Value;
    }
}
