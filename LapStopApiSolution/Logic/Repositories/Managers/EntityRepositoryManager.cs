﻿using Contracts.IRepositories.Managers;
using Repositories.Entities;

namespace Repositories.Managers
{
    internal sealed class EntityRepositoryManager : IEntityRepositoryManager
    {
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

        public EntityRepositoryManager(EntityRepositoryParams repoParams)
        {
            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(repoParams));
            _cartRepository = new Lazy<ICartRepository>(() => new CartRepository(repoParams));
            _cartItemRepository = new Lazy<ICartItemRepository>(() => new CartItemRepository(repoParams));
            _customerAccountRepository = new Lazy<ICustomerAccountRepository>(() => new CustomerAccountRepository(repoParams));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(repoParams));
            _employeeAccountRepository = new Lazy<IEmployeeAccountRepository>(() => new EmployeeAccountRepository(repoParams));
            _employeeGalleryRepository = new Lazy<IEmployeeGalleryRepository>(() => new EmployeeGalleryRepository(repoParams));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repoParams));
            _employeeRoleRepository = new Lazy<IEmployeeRoleRepository>(() => new EmployeeRoleRepository(repoParams));
            _employeeStatusRepository = new Lazy<IEmployeeStatusRepository>(() => new EmployeeStatusRepository(repoParams));
            _exportedInvoiceRepository = new Lazy<IExportedInvoiceRepository>(() => new ExportedInvoiceRepository(repoParams));
            _exportedInvoiceDetailRepository = new Lazy<IExportedInvoiceDetailRepository>(() => new ExportedInvoiceDetailRepository(repoParams));
            _importedInvoiceRepository = new Lazy<IImportedInvoiceRepository>(() => new ImportedInvoiceRepository(repoParams));
            _importedInvoiceDetailRepository = new Lazy<IImportedInvoiceDetailRepository>(() => new ImportedInvoiceDetailRepository(repoParams));
            _invoiceStatusRepository = new Lazy<IInvoiceStatusRepository>(() => new InvoiceStatusRepository(repoParams));
            _productBrandRepository = new Lazy<IProductBrandRepository>(() => new ProductBrandRepository(repoParams));
            _productGalleryRepository = new Lazy<IProductGalleryRepository>(() => new ProductGalleryRepository(repoParams));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repoParams));
            _productStatusRepository = new Lazy<IProductStatusRepository>(() => new ProductStatusRepository(repoParams));
            _salesOrderRepository = new Lazy<ISalesOrderRepository>(() => new SalesOrderRepository(repoParams));
            _salesOrderDetailRepository = new Lazy<ISalesOrderDetailRepository>(() => new SalesOrderDetailRepository(repoParams));
            _salesOrderStatusRepository = new Lazy<ISalesOrderStatusRepository>(() => new SalesOrderStatusRepository(repoParams));
        }

        public IBrandRepository Brand => _brandRepository.Value;

        public ICartRepository Cart => _cartRepository.Value;

        public ICartItemRepository CartItem => _cartItemRepository.Value;

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
