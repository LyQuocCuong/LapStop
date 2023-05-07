using Domains.Base;
using Domains.Models;
using Entities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public sealed class LapStopContext : DbContext
    {
        public LapStopContext(DbContextOptions<LapStopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyOrderConfigExt();

            modelBuilder.ApplyAttributeConfigExt();

            modelBuilder.ApplyRelationshipConfigExt();

            modelBuilder.ApplySeedingDataExt();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is BaseModel && 
                                       (e.State == EntityState.Added ||
                                        e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }
        public DbSet<EmployeeGallery> EmployeeGalleries { get; set; }
        public DbSet<EmployeeRole>  EmployeeRoles { get; set; }  
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<ExportedInvoice> ExportedInvoices { get; set; }
        public DbSet<ExportedInvoiceDetail> ExportedInvoiceDetail { get;set; }
        public DbSet<ImportedInvoice> ImportedInvoices { get;set; }
        public DbSet<ImportedInvoiceDetail> ImportedInvoiceDetail { get;set; }
        public DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetail { get; set;}
        public DbSet<SalesOrderStatus> SalesOrderStatus { get; set;}
    }
}
