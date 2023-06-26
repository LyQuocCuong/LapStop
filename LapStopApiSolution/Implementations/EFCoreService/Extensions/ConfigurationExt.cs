using EFCoreService.Configurations.Entities;
using EFCoreService.Configurations.Identities;

namespace EFCoreService.Extensions
{
    public static class ConfigurationExt
    {
        public static void ApplyOrderConfigExt(this ModelBuilder modelBuilder)
        {

            // When you config BaseModel
            // => This means that include Mapping it
            // => But we don't want to map it
            // => MUST config for EACH model
            #region BASE MODEL (ERROR)

            //modelBuilder.Entity<BaseModel>()
            //    .Property(b => b.CreatedDate)
            //    .HasColumnOrder(27);

            //modelBuilder.Entity<BaseModel>()
            //    .Property(b => b.UpdatedDate)
            //    .HasColumnOrder(28);

            //modelBuilder.Entity<BaseModel>()
            //    .Property(b => b.IsRemoved)
            //    .HasColumnOrder(29);

            #endregion

            // CONFIG the ORDER for the all Models

            #region Brand

            modelBuilder.Entity<Brand>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<Brand>()
                .Property(b => b.Name)
                .HasColumnOrder(2);

            modelBuilder.Entity<Brand>()
                .Property(b => b.Description)
                .HasColumnOrder(3);

            modelBuilder.Entity<Brand>()
                .Property(b => b.AvatarUrl)
                .HasColumnOrder(4);

            modelBuilder.Entity<Brand>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<Brand>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<Brand>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region Cart

            modelBuilder.Entity<Cart>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<Cart>()
                .Property(b => b.CustomerId)
                .HasColumnOrder(2);

            modelBuilder.Entity<Cart>()
                .Property(b => b.Total)
                .HasColumnOrder(3);

            modelBuilder.Entity<Cart>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<Cart>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<Cart>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region CartItem

            modelBuilder.Entity<CartItem>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<CartItem>()
                .Property(b => b.CartId)
                .HasColumnOrder(2);

            modelBuilder.Entity<CartItem>()
                .Property(b => b.ProductId)
                .HasColumnOrder(3);

            modelBuilder.Entity<CartItem>()
                .Property(b => b.Quantity)
                .HasColumnOrder(4);

            modelBuilder.Entity<CartItem>()
                .Property(b => b.SellingPrice)
                .HasColumnOrder(5);

            modelBuilder.Entity<CartItem>()
                .Property(b => b.SubTotal)
                .HasColumnOrder(6);

            modelBuilder.Entity<CartItem>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<CartItem>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<CartItem>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region Customer

            modelBuilder.Entity<Customer>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<Customer>()
                .Property(b => b.FirstName)
                .HasColumnOrder(2);

            modelBuilder.Entity<Customer>()
                .Property(b => b.LastName)
                .HasColumnOrder(3);

            modelBuilder.Entity<Customer>()
                .Property(b => b.Address)
                .HasColumnOrder(4);

            modelBuilder.Entity<Customer>()
                .Property(b => b.Phone)
                .HasColumnOrder(5);

            modelBuilder.Entity<Customer>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<Customer>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<Customer>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region CustomerAccount

            modelBuilder.Entity<CustomerAccount>()
                .Property(b => b.CustomerId)
                .HasColumnOrder(1);

            modelBuilder.Entity<CustomerAccount>()
                .Property(b => b.Username)
                .HasColumnOrder(2);

            modelBuilder.Entity<CustomerAccount>()
                .Property(b => b.Password)
                .HasColumnOrder(3);

            modelBuilder.Entity<CustomerAccount>()
                .Property(b => b.IsActivate)
                .HasColumnOrder(4);

            modelBuilder.Entity<CustomerAccount>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<CustomerAccount>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<CustomerAccount>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region Employee

            modelBuilder.Entity<Employee>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<Employee>()
                .Property(b => b.EmployeeRoleId)
                .HasColumnOrder(2);

            modelBuilder.Entity<Employee>()
                .Property(b => b.EmployeeStatusId)
                .HasColumnOrder(3);

            modelBuilder.Entity<Employee>()
                .Property(b => b.EmployeeCode)
                .HasColumnOrder(4);

            modelBuilder.Entity<Employee>()
                .Property(b => b.FirstName)
                .HasColumnOrder(5);

            modelBuilder.Entity<Employee>()
                .Property(b => b.LastName)
                .HasColumnOrder(6);

            modelBuilder.Entity<Employee>()
                .Property(b => b.IsMale)
                .HasColumnOrder(7);

            modelBuilder.Entity<Employee>()
                .Property(b => b.DOB)
                .HasColumnOrder(8);

            modelBuilder.Entity<Employee>()
                .Property(b => b.Address)
                .HasColumnOrder(9);

            modelBuilder.Entity<Employee>()
                .Property(b => b.Email)
                .HasColumnOrder(10);

            modelBuilder.Entity<Employee>()
                .Property(b => b.Phone)
                .HasColumnOrder(11);

            modelBuilder.Entity<Employee>()
                .Property(b => b.AvatarUrl)
                .HasColumnOrder(12);

            modelBuilder.Entity<Employee>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<Employee>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<Employee>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region EmployeeAccount

            modelBuilder.Entity<EmployeeAccount>()
                .Property(b => b.EmployeeId)
                .HasColumnOrder(1);

            modelBuilder.Entity<EmployeeAccount>()
                .Property(b => b.Username)
                .HasColumnOrder(2);

            modelBuilder.Entity<EmployeeAccount>()
                .Property(b => b.Password)
                .HasColumnOrder(3);

            modelBuilder.Entity<EmployeeAccount>()
                .Property(b => b.IsActivate)
                .HasColumnOrder(4);

            modelBuilder.Entity<EmployeeAccount>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<EmployeeAccount>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<EmployeeAccount>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region EmployeeGallery

            modelBuilder.Entity<EmployeeGallery>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<EmployeeGallery>()
                .Property(b => b.EmployeeId)
                .HasColumnOrder(2);

            modelBuilder.Entity<EmployeeGallery>()
                .Property(b => b.Title)
                .HasColumnOrder(3);

            modelBuilder.Entity<EmployeeGallery>()
                .Property(b => b.Url)
                .HasColumnOrder(4);

            modelBuilder.Entity<EmployeeGallery>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<EmployeeGallery>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<EmployeeGallery>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region EmployeeRole

            modelBuilder.Entity<EmployeeRole>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<EmployeeRole>()
                .Property(b => b.Name)
                .HasColumnOrder(2);

            modelBuilder.Entity<EmployeeRole>()
                .Property(b => b.IsEnable)
                .HasColumnOrder(3);

            modelBuilder.Entity<EmployeeRole>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<EmployeeRole>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<EmployeeRole>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region EmployeeStatus

            modelBuilder.Entity<EmployeeStatus>()
            .Property(b => b.Id)
            .HasColumnOrder(1);

            modelBuilder.Entity<EmployeeStatus>()
                .Property(b => b.Name)
                .HasColumnOrder(2);

            modelBuilder.Entity<EmployeeStatus>()
                .Property(b => b.IsEnable)
                .HasColumnOrder(3);

            modelBuilder.Entity<EmployeeStatus>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<EmployeeStatus>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<EmployeeStatus>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region ExportedInvoice

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.SalesOrderId)
                .HasColumnOrder(2);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.EmployeeId)
                .HasColumnOrder(3);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.InvoiceStatusId)
                .HasColumnOrder(4);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.InvoiceCode)
                .HasColumnOrder(5);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.InvoiceDate)
                .HasColumnOrder(6);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.Total)
                .HasColumnOrder(7);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<ExportedInvoice>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region ExportedInvoiceDetail

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.ExportedInvoiceId)
                .HasColumnOrder(2);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.ProductId)
                .HasColumnOrder(3);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.ProductBarcode)
                .HasColumnOrder(4);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.SellingPrice)
                .HasColumnOrder(5);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.Quantity)
                .HasColumnOrder(6);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.SubTotal)
                .HasColumnOrder(7);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<ExportedInvoiceDetail>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region ImportedInvoice

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.EmployeeId)
                .HasColumnOrder(2);

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.InvoiceStatusId)
                .HasColumnOrder(3);

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.InvoiceCode)
                .HasColumnOrder(4);

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.InvoiceDate)
                .HasColumnOrder(5);

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.Total)
                .HasColumnOrder(6);

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<ImportedInvoice>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region ImportedInvoiceDetail

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.ImportedInvoiceId)
                .HasColumnOrder(2);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.ProductId)
                .HasColumnOrder(3);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.ProductBarcode)
                .HasColumnOrder(4);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.CostPrice)
                .HasColumnOrder(5);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.Quantity)
                .HasColumnOrder(6);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.SubTotal)
                .HasColumnOrder(7);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<ImportedInvoiceDetail>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region InvoiceStatus

            modelBuilder.Entity<InvoiceStatus>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<InvoiceStatus>()
                .Property(b => b.Name)
                .HasColumnOrder(2);

            modelBuilder.Entity<InvoiceStatus>()
                .Property(b => b.Description)
                .HasColumnOrder(3);

            modelBuilder.Entity<InvoiceStatus>()
                .Property(b => b.IsEnable)
                .HasColumnOrder(4);

            modelBuilder.Entity<InvoiceStatus>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<InvoiceStatus>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<InvoiceStatus>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region Product

            modelBuilder.Entity<Product>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<Product>()
                .Property(b => b.ProductStatusId)
                .HasColumnOrder(2);

            modelBuilder.Entity<Product>()
                .Property(b => b.ProductCode)
                .HasColumnOrder(3);

            modelBuilder.Entity<Product>()
                .Property(b => b.Name)
                .HasColumnOrder(4);

            modelBuilder.Entity<Product>()
                .Property(b => b.Description)
                .HasColumnOrder(5);

            modelBuilder.Entity<Product>()
                .Property(b => b.AvatarUrl)
                .HasColumnOrder(6);

            modelBuilder.Entity<Product>()
                .Property(b => b.OriginalPrice)
                .HasColumnOrder(7);

            modelBuilder.Entity<Product>()
                .Property(b => b.CurrentPrice)
                .HasColumnOrder(8);

            modelBuilder.Entity<Product>()
                .Property(b => b.SellingPrice)
                .HasColumnOrder(9);

            modelBuilder.Entity<Product>()
                .Property(b => b.IsHiddenInStore)
                .HasColumnOrder(10);

            modelBuilder.Entity<Product>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<Product>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<Product>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region ProductBrand

            modelBuilder.Entity<ProductBrand>()
            .Property(b => b.ProductId)
            .HasColumnOrder(1);

            modelBuilder.Entity<ProductBrand>()
                .Property(b => b.BrandId)
                .HasColumnOrder(2);

            modelBuilder.Entity<ProductBrand>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<ProductBrand>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<ProductBrand>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region ProductGallery

            modelBuilder.Entity<ProductGallery>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<ProductGallery>()
                .Property(b => b.ProductId)
                .HasColumnOrder(2);

            modelBuilder.Entity<ProductGallery>()
                .Property(b => b.Title)
                .HasColumnOrder(3);

            modelBuilder.Entity<ProductGallery>()
                .Property(b => b.Url)
                .HasColumnOrder(4);

            modelBuilder.Entity<ProductGallery>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<ProductGallery>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<ProductGallery>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region ProductStatus

            modelBuilder.Entity<ProductStatus>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<ProductStatus>()
                .Property(b => b.Name)
                .HasColumnOrder(2);

            modelBuilder.Entity<ProductStatus>()
                .Property(b => b.Description)
                .HasColumnOrder(3);

            modelBuilder.Entity<ProductStatus>()
                .Property(b => b.IsEnable)
                .HasColumnOrder(4);

            modelBuilder.Entity<ProductStatus>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<ProductStatus>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<ProductStatus>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region SalesOrder

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.CustomerId)
                .HasColumnOrder(2);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.SalesOrderStatusId)
                .HasColumnOrder(3);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.OrderDate)
                .HasColumnOrder(4);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.Address)
                .HasColumnOrder(5);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.Phone)
                .HasColumnOrder(6);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.Total)
                .HasColumnOrder(7);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<SalesOrder>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region SalesOrderDetail

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.SalesOrderId)
                .HasColumnOrder(2);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.ProductId)
                .HasColumnOrder(3);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.Quantity)
                .HasColumnOrder(4);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.SellingPrice)
                .HasColumnOrder(5);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.SubTotal)
                .HasColumnOrder(6);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<SalesOrderDetail>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

            #region SalesOrderStatus

            modelBuilder.Entity<SalesOrderStatus>()
                .Property(b => b.Id)
                .HasColumnOrder(1);

            modelBuilder.Entity<SalesOrderStatus>()
                .Property(b => b.Name)
                .HasColumnOrder(2);

            modelBuilder.Entity<SalesOrderStatus>()
                .Property(b => b.Description)
                .HasColumnOrder(3);

            modelBuilder.Entity<SalesOrderStatus>()
                .Property(b => b.IsEnable)
                .HasColumnOrder(4);

            modelBuilder.Entity<SalesOrderStatus>()
                .Property(b => b.CreatedDate)
                .HasColumnOrder(27);

            modelBuilder.Entity<SalesOrderStatus>()
                .Property(b => b.UpdatedDate)
                .HasColumnOrder(28);

            modelBuilder.Entity<SalesOrderStatus>()
                .Property(b => b.IsRemoved)
                .HasColumnOrder(29);

            #endregion

        }

        public static void ApplyAttributeConfigExt(this ModelBuilder modelBuilder)
        {
            #region CUSTOMER ACCOUNT

            modelBuilder.Entity<CustomerAccount>().ToTable("CustomerAccount");
            modelBuilder.Entity<CustomerAccount>()
                .HasKey(ca => ca.CustomerId)
                .HasName("CustomerId");
            modelBuilder.Entity<CustomerAccount>()
                .Property(ca => ca.Username)
                .HasColumnName("Username")
                .IsRequired(true); // NOT nullable

            #endregion

            #region EMPLOYEE ACCOUNT

            modelBuilder.Entity<EmployeeAccount>().ToTable("EmployeeAccount");
            modelBuilder.Entity<EmployeeAccount>()
                .HasKey(ea => ea.EmployeeId)
                .HasName("EmployeeId");
            modelBuilder.Entity<EmployeeAccount>()
                .Property(ea => ea.Username)
                .HasColumnName("Username")
                .IsRequired(true); // NOT nullable

            #endregion

            #region PRODUCT BRAND

            modelBuilder.Entity<ProductBrand>().ToTable("ProductBrand");
            modelBuilder.Entity<ProductBrand>()
                .HasKey(pb => new { pb.ProductId, pb.BrandId });
            modelBuilder.Entity<ProductBrand>()
                .Property(pb => pb.ProductId)
                .HasColumnName("ProductId")
                .IsRequired(true); // NOT nullable
            modelBuilder.Entity<ProductBrand>()
                .Property(pb => pb.BrandId)
                .HasColumnName("BrandId")
                .IsRequired(true); // NOT nullable

            #endregion
        }

        public static void ApplyRelationshipConfigExt(this ModelBuilder modelBuilder)
        {
            /// <summary>
            /// One-To-Many: START from the class CONTAINING ICollection<>
            /// One-To-One: START from the class does NOT contain FK_ID
            /// </summary>

            #region BRAND

            // (1) Brand --> (N) ProductBrand
            modelBuilder.Entity<Brand>()
                .HasMany<ProductBrand>(b => b.ProductsOfABrand)
                .WithOne(pb => pb.Brand)
                .HasForeignKey(pb => pb.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region CART

            // (1) Cart --> (N) CartItem 
            modelBuilder.Entity<Cart>()
                .HasMany<CartItem>(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region CUSTOMER

            // (1) Customer <--> (1) Cart
            modelBuilder.Entity<Customer>()
                .HasOne<Cart>(cus => cus.Cart)
                .WithOne(c => c.Customer)
                .HasForeignKey<Cart>(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Customer <--> (1) CustomerAccount
            modelBuilder.Entity<Customer>()
                .HasOne<CustomerAccount>(c => c.CustomerAccount)
                .WithOne(ca => ca.Customer)
                .HasForeignKey<CustomerAccount>(ca => ca.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Customer --> (N) SalesOrder
            modelBuilder.Entity<Customer>()
                .HasMany<SalesOrder>(cus => cus.SalesOrders)
                .WithOne(so => so.Customer)
                .HasForeignKey(so => so.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region EMPLOYEE

            // (1) Employee <--> (1) EmployeeAccount
            modelBuilder.Entity<Employee>()
                .HasOne<EmployeeAccount>(e => e.EmployeeAccount)
                .WithOne(ea => ea.Employee)
                .HasForeignKey<EmployeeAccount>(ea => ea.EmployeeId);

            // (1) Employee --> (N) EmployeeGallery
            modelBuilder.Entity<Employee>()
                .HasMany<EmployeeGallery>(e => e.EmployeeGalleries)
                .WithOne(eg => eg.Employee)
                .HasForeignKey(eg => eg.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Employee --> (N) ImportedInvoice
            modelBuilder.Entity<Employee>()
                .HasMany<ImportedInvoice>(e => e.ImportedInvoices)
                .WithOne(ii => ii.Employee)
                .HasForeignKey(ii => ii.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Employee --> (N) ExportedInvoice
            modelBuilder.Entity<Employee>()
                .HasMany<ExportedInvoice>(e => e.ExportedInvoices)
                .WithOne(ei => ei.Employee)
                .HasForeignKey(ei => ei.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region EMPLOYEE ROLE

            // (1) EmployeeRole --> (N) Employee
            modelBuilder.Entity<EmployeeRole>()
                .HasMany<Employee>(er => er.Employees)
                .WithOne(e => e.EmployeeRole)
                .HasForeignKey(e => e.EmployeeRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region EMPLOYEE STATUS

            // (1) EmployeeStatus --> (N) Employee
            modelBuilder.Entity<EmployeeStatus>()
                .HasMany<Employee>(es => es.Employees)
                .WithOne(e => e.EmployeeStatus)
                .HasForeignKey(e => e.EmployeeStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region EXPORTED INVOICES

            // (1) ExportedInvoice --> (N) ExportedInvoiceDetail
            modelBuilder.Entity<ExportedInvoice>()
                .HasMany<ExportedInvoiceDetail>(ei => ei.ExportedInvoiceDetails)
                .WithOne(eid => eid.ExportedInvoice)
                .HasForeignKey(eid => eid.ExportedInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region IMPORTED INVOICES

            // (1) ImportedInvoice --> (N) ImportedInvoiceDetail
            modelBuilder.Entity<ImportedInvoice>()
                .HasMany<ImportedInvoiceDetail>(ip => ip.ImportedInvoiceDetails)
                .WithOne(iid => iid.ImportedInvoice)
                .HasForeignKey(iid => iid.ImportedInvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region INVOICE STATUS

            // (1) InvoiceStatus --> (N) ImportedInvoice
            modelBuilder.Entity<InvoiceStatus>()
                .HasMany<ImportedInvoice>(ins => ins.ImportedInvoices)
                .WithOne(ii => ii.InvoiceStatus)
                .HasForeignKey(ii => ii.InvoiceStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) InvoiceStatus --> (N) ExportedInvoice
            modelBuilder.Entity<InvoiceStatus>()
                .HasMany<ExportedInvoice>(ins => ins.ExportedInvoices)
                .WithOne(ei => ei.InvoiceStatus)
                .HasForeignKey(ei => ei.InvoiceStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region PRODUCT

            // (1) Product --> (N) ProductBrand
            modelBuilder.Entity<Product>()
                .HasMany<ProductBrand>(p => p.BrandsOfAProduct)
                .WithOne(boap => boap.Product)
                .HasForeignKey(boap => boap.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) ProductGallery
            modelBuilder.Entity<Product>()
                .HasMany<ProductGallery>(p => p.ProductGalleries)
                .WithOne(pg => pg.Product)
                .HasForeignKey(pg => pg.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) CartItem
            modelBuilder.Entity<Product>()
                .HasMany<CartItem>(p => p.CartItems)
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) SalesOrderDetail
            modelBuilder.Entity<Product>()
                .HasMany<SalesOrderDetail>(p => p.SalesOrderDetails)
                .WithOne(sod => sod.Product)
                .HasForeignKey(sod => sod.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) ExportedInvoiceDetail
            modelBuilder.Entity<Product>()
                .HasMany<ExportedInvoiceDetail>(p => p.ExportedInvoiceDetails)
                .WithOne(eid => eid.Product)
                .HasForeignKey(eid => eid.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) Product --> (N) ImportedInvoiceDetail
            modelBuilder.Entity<Product>()
                .HasMany<ImportedInvoiceDetail>(p => p.ImportedInvoiceDetails)
                .WithOne(iid => iid.Product)
                .HasForeignKey(iid => iid.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region PRODUCT STATUS

            // (1) ProductStatus --> (N) Product
            modelBuilder.Entity<ProductStatus>()
                .HasMany<Product>(ps => ps.Products)
                .WithOne(p => p.ProductStatus)
                .HasForeignKey(p => p.ProductStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region SALES ORDER

            // (1) SalesOrder <--> (1) ExportedInvoice
            modelBuilder.Entity<SalesOrder>()
                .HasOne<ExportedInvoice>(so => so.ExportedInvoice)
                .WithOne(ei => ei.SalesOrder)
                .HasForeignKey<ExportedInvoice>(ei => ei.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // (1) SalesOrder --> (N) SalesOrderDetail
            modelBuilder.Entity<SalesOrder>()
                .HasMany<SalesOrderDetail>(so => so.SalesOrderDetails)
                .WithOne(sod => sod.SalesOrder)
                .HasForeignKey(sod => sod.SalesOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region SALES ORDER STATUS

            // (1) SalesOrderStatus --> (N) SalesOrder
            modelBuilder.Entity<SalesOrderStatus>()
                .HasMany<SalesOrder>(sos => sos.SalesOrders)
                .WithOne(so => so.SalesOrderStatus)
                .HasForeignKey(so => so.SalesOrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

        }

        public static void ApplySeedingDataExt(this ModelBuilder modelBuilder)
        {
            /// BOTH Attribute and Relationship can be DEFINED in this [ENTITY]Config.cs
            /// But I just want to use this class for Seeding Data
            /// I used EXTENSION_METHOD to define Attribute and Relationship

            modelBuilder.ApplyConfiguration<EmployeeRole>(new EmployeeRoleConfig());
            modelBuilder.ApplyConfiguration<EmployeeStatus>(new EmployeeStatusConfig());
            modelBuilder.ApplyConfiguration<InvoiceStatus>(new InvoiceStatusConfig());
            modelBuilder.ApplyConfiguration<ProductStatus>(new ProductStatusConfig());
            modelBuilder.ApplyConfiguration<SalesOrderStatus>(new SalesOrderStatusConfig());
        }

        public static void ApplySeedingIdentityDataExt(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<IdentRole>(new IdentRoleConfig());
        }
    }
}
